namespace api_airport.Interfaces;

public interface IMapper<TEntity, TDto, TCreateDto>
{
    TDto MapToDto(TEntity entity);
    TEntity MapToEntity(TCreateDto createDto);
    TEntity MapToEntity(Guid id, TCreateDto createDto);
}
