namespace api_airport.Services.Interfaces;

public interface IBaseService<TDto, TCreateDto>
{
    Task<List<TDto>> GetListAsync();
    Task<TDto?> GetItemAsync(Guid id);
    Task<string> AddAsync(TCreateDto createDto);
    Task UpdateAsync(Guid id, TCreateDto updateDto);
    Task DeleteAsync(Guid id);
}
