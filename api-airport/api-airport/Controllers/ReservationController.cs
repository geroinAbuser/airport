using Microsoft.AspNetCore.Mvc;
using api_airport.DTOs.Reservation;
using api_airport.Services.Interfaces;
using api_airport.Emums;
using api_airport.Filters;

namespace api_airport.Controllers;

[Route("api/[controller]")]
public class ReservationController : BaseController<ReservationDto, CreateReservationDto>
{
    private readonly IReservationService _reservationService;
    public ReservationController(IReservationService service) : base(service) 
    {
        _reservationService = service;
    }

    [HttpPut("{id}")]
    [RoleRequirement(UserRole.User)]
    public override async Task<ActionResult> UpdateItem(Guid id, CreateReservationDto updatedItem)
    {
        await _reservationService.UpdateAsync(id, updatedItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [RoleRequirement(UserRole.User)]
    public override async Task<ActionResult> DeleteItem(Guid id)
    {
        await _reservationService.DeleteAsync(id);
        return NoContent();
    }
}

