namespace api_airport.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetListAsync();
    Task<TEntity> GetItemAsync(Guid id);
    Task<string> AddAsync(TEntity entity);
    Task UpdateAsync(Guid id, TEntity entity);
    Task DeleteAsync(Guid id);
}
