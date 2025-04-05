using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Airport;
using api_airport.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace api_airport.Controllers;

[Authorize]
[Route("api/[controller]")]
public class AirportController : BaseController<AirportDto, CreateAirportDto>
{
    public AirportController(IAirportService service) : base(service) { }
}
