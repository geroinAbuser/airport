using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Airplane;
using api_airport.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace api_airport.Controllers;

[Authorize]
[Route("api/[controller]")]
public class AirplaneController : BaseController<AirplaneDto, CreateAirplaneDto>
{
    public AirplaneController(IAirplaneService service) : base(service) { }
}
