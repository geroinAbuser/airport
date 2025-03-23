using api_airport.DTOs.Airplane;
using api_airport.Entity.Airplane;
using api_airport.Interfaces;

namespace api_airport.Mappings;

public class AirplaneMapper : IMapper<Airplane, AirplaneDto, CreateAirplaneDto>
{
    public AirplaneDto MapToDto(Airplane entity)
    {
        return new AirplaneDto
        {
            Id = entity.Id,
            Model = entity.Model,
            Capacity = entity.Capacity,
            AirportName = entity.Airport?.Name,
            AirportId = entity.AirportId
        };
    }

    public Airplane MapToEntity(CreateAirplaneDto createDto)
    {
        return new Airplane
        {
            Model = createDto.Model,
            Capacity = createDto.Capacity,
            AirportId = createDto.AirportId 
        };
    }

    public Airplane MapToEntity(Guid id, CreateAirplaneDto createDto)
    {
        return new Airplane
        {
            Id = id,
            Model = createDto.Model,
            Capacity = createDto.Capacity,
            AirportId = createDto.AirportId
        };
    }
}
