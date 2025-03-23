using api_airport.Services.Auth;
using api_airport.Services.Interfaces;

namespace api_airport.Middleware;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthGrpcClient _authGrpcClient;

    private static readonly HashSet<string> _excludedEndpoints = new()
    {
        "/api/flight" 
    };

    public AuthorizationMiddleware(RequestDelegate next, AuthGrpcClient authGrpcClient)
    {
        _next = next;
        _authGrpcClient = authGrpcClient;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userService)
    {
        var requestPath = context.Request.Path.Value?.ToLower();

        if (requestPath != null && _excludedEndpoints.Contains(requestPath) && context.Request.Method == "GET")
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token) || token == "null")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Token is required");
            return;
        }

        var response = await _authGrpcClient.ValidateTokenAsync(token);

        if (!response.IsValid)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid token");
            return;
        }

        userService.SetUser(Guid.Parse(response.UserId), response.Username, response.Email, response.Role);

        await _next(context);
    }
}
