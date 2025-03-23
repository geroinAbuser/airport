using api_airport.DTOs.Flight;

namespace api_airport.Services.Interfaces;

public interface IFlightService : IBaseService<FlightDto, CreateFlightDto>
{
}
