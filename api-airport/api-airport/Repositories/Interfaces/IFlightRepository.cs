using api_airport.Entity.Flight;

namespace api_airport.Repositories.Interfaces;

public interface IFlightRepository : IBaseRepository<Flight>
{
    Task<Flight> GetFlightWithLockAsync(Guid flightId);
}
