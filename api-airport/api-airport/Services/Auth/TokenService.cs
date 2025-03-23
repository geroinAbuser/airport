using System.IdentityModel.Tokens.Jwt;

public static class TokenService
{
    public static int GetUserIdFromToken(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.ContainsKey("Authorization"))
        {
            throw new UnauthorizedAccessException("Authorization header missing.");
        }

        var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedAccessException("Token is missing.");
        }

        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Identifier");

        if (userIdClaim == null)
        {
            throw new UnauthorizedAccessException("User ID not found in token.");
        }

        return int.Parse(userIdClaim.Value);
    }
}