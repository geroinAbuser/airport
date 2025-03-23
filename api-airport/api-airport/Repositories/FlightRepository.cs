using api_airport.Entity.Flight;
using api_airport.Repositories.Interfaces;
using api_airport.Data;
using Microsoft.EntityFrameworkCore;

namespace api_airport.Repositories;

public class FlightRepository : BaseRepository<Flight>, IFlightRepository
{
    private readonly ApplicationDbContext _context;
    public FlightRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<List<Flight>> GetListAsync()
    {
        return await _context.Flights
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .Include(f => f.Airplane)
            .ToListAsync();
    }

    public override async Task<Flight> GetItemAsync(Guid id)
    {
        return await _context.Flights
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .Include(f => f.Airplane)
            .FirstOrDefaultAsync(f => f.Id == id) ?? new Flight();
    }

    public async Task<Flight> GetFlightWithLockAsync(Guid flightId)
    {
        return await _context.Flights
            .FromSqlRaw("SELECT * FROM main.Flights WITH (UPDLOCK) WHERE Id = {0}", flightId)
            .FirstOrDefaultAsync() ?? new Flight();
    }
}
