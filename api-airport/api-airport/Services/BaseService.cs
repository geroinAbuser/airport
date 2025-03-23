using api_airport.Interfaces;
using api_airport.Repositories.Interfaces;
using api_airport.Services.Interfaces;

namespace api_airport.Services;

public abstract class BaseService<TEntity, TDto, TCreateDto> : IBaseService<TDto, TCreateDto> where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IMapper<TEntity, TDto, TCreateDto> _mapper;

    protected BaseService(IBaseRepository<TEntity> repository, IMapper<TEntity, TDto, TCreateDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<List<TDto>> GetListAsync()
    {
        var entities = await _repository.GetListAsync();
        return entities.Select(entity => _mapper.MapToDto(entity)).ToList();
    }

    public virtual async Task<TDto?> GetItemAsync(Guid id)
    {
        var entity = await _repository.GetItemAsync(id);
        return _mapper.MapToDto(entity);
    }

    public virtual async Task<string> AddAsync(TCreateDto createDto)
    {
        var entity = _mapper.MapToEntity(createDto);
        return await _repository.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(Guid id, TCreateDto updateDto)
    {
        var entity = _mapper.MapToEntity(id, updateDto);
        await _repository.UpdateAsync(id, entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}

