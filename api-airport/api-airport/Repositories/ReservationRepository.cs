using api_airport.Data;
using api_airport.Entity.Reservation;
using api_airport.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace api_airport.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    private readonly ApplicationDbContext _context;
    public ReservationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Reservation>> GetListForUserAsync(Guid userId)
    {
        return await _context.Reservations
            .Where(r => r.UserId == userId)
            .Include(r => r.Flight)
            .Include(r => r.Passengers)
            .ToListAsync();
    }

    public override async Task<List<Reservation>> GetListAsync()
    {
        return await _context.Reservations
            .Include(r => r.Flight)
            .Include(r => r.Passengers)
            .ToListAsync();
    }

    public override async Task<Reservation> GetItemAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.Flight)
            .Include(r => r.Passengers)
            .FirstOrDefaultAsync(r => r.Id == id) ?? new Reservation();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }
}
