using api_airport.User;

namespace api_airport.Middleware;

public class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICurrentUser currentUser)
    {
        var user = context.User;

        var userIdClaim = user?.FindFirst("userId")?.Value;
        var nameClaim = user?.FindFirst("name")?.Value;
        var surnameClaim = user?.FindFirst("surname")?.Value;
        var emailClaim = user?.FindFirst("email")?.Value;
        var roleClaim = user?.FindFirst("role")?.Value;

        if (Guid.TryParse(userIdClaim, out var userId))
        {
            currentUser.UserId = userId;
            currentUser.Name = nameClaim;
            currentUser.Surname = surnameClaim;
            currentUser.Email = emailClaim;
            currentUser.Role = roleClaim;
        }

        await _next(context);
    }
}
