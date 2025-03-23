using api_airport.Data;
using api_airport.Entity.Airplane;
using api_airport.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_airport.Repositories;

public class AirplaneRepository : BaseRepository<Airplane>, IAirplaneRepository
{
    private readonly ApplicationDbContext _context;
    public AirplaneRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<List<Airplane>> GetListAsync()
    {
        return await _context.Airplanes
                             .Include(a => a.Airport)  
                             .ToListAsync();
    }

    public override async Task<Airplane> GetItemAsync(Guid id)
    {
        return await _context.Airplanes
                                 .Include(a => a.Airport) 
                                 .FirstOrDefaultAsync(a => a.Id == id) ?? new Airplane();
    }
}
