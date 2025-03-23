using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Airplane;
using api_airport.Services.Interfaces;
using api_airport.Emums;
using api_airport.Filters;

namespace api_airport.Controllers;

[Route("api/[controller]")]
[RoleRequirement(UserRole.Administrator)]
public class AirplaneController : BaseController<AirplaneDto, CreateAirplaneDto>
{
    public AirplaneController(IAirplaneService service) : base(service) { }
}
