using api_airport.Entity.Reservation;
using Microsoft.EntityFrameworkCore.Storage;

namespace api_airport.Repositories.Interfaces;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<List<Reservation>> GetListForUserAsync(Guid userId);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task SaveChangesAsync();
    Task RollbackTransactionAsync(IDbContextTransaction transaction);
    Task CommitTransactionAsync(IDbContextTransaction transaction);
}
