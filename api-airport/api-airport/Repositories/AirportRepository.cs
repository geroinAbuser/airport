using api_airport.Data;
using api_airport.Entity.Airport;
using api_airport.Repositories.Interfaces;

namespace api_airport.Repositories;

public class AirportRepository : BaseRepository<Airport>, IAirportRepository
{
    public AirportRepository(ApplicationDbContext context) : base(context)
    {
    }
}
