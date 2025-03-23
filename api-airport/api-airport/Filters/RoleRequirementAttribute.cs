using Microsoft.AspNetCore.Mvc.Filters;
using api_airport.Emums;
using api_airport.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_airport.Filters;

public class RoleRequirementAttribute : Attribute, IAuthorizationFilter
{
    private readonly UserRole _requiredRole;

    public RoleRequirementAttribute(UserRole requiredRole)
    {
        _requiredRole = requiredRole;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

        if (userService == null || !Enum.TryParse(userService.Role, out UserRole userRole) || userRole < _requiredRole)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}