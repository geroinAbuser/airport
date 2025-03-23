using api_airport.Data;
using api_airport.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_airport.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetItemAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<string> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        var id = typeof(TEntity).GetProperty("Id")?.GetValue(entity);
        return id.ToString() ?? throw new InvalidOperationException("Entity does not have a valid Id property.");
    }

    public async Task UpdateAsync(Guid id, TEntity entity)
    {
        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException("Entity not found.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(); 
        }
    }
}
