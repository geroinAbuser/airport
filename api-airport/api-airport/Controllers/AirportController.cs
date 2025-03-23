using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Airport;
using api_airport.Services.Interfaces;
using api_airport.Emums;
using api_airport.Filters;

namespace api_airport.Controllers;

[Route("api/[controller]")]
[RoleRequirement(UserRole.Administrator)]
public class AirportController : BaseController<AirportDto, CreateAirportDto>
{
    public AirportController(IAirportService service) : base(service) { }
}
