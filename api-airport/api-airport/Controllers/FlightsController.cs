using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Flight;
using api_airport.Services.Interfaces;
using api_airport.Emums;
using api_airport.Filters;

namespace api_airport.Controllers;

[Route("api/[controller]")]
public class FlightController : BaseController<FlightDto, CreateFlightDto>
{
    private readonly IFlightService _flightService;
    public FlightController(IFlightService service) : base(service) 
    {
        _flightService = service;
    }


    [HttpPost]
    [RoleRequirement(UserRole.Admin)]
    public override async Task<ActionResult<string>> AddItem(CreateFlightDto newItem)
    {
        var response = await _flightService.AddAsync(newItem);
        return StatusCode(StatusCodes.Status201Created, response);
    }
}
