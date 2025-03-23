using api_airport.DTOs.Airport;
using api_airport.Entity.Airport;
using api_airport.Interfaces;

namespace api_airport.Mappings;

public class AirportMapper : IMapper<Airport, AirportDto, CreateAirportDto>
{
    public AirportDto MapToDto(Airport entity)
    {
        return new AirportDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code,
            City = entity.City,
            Country = entity.Country
        };
    }

    public Airport MapToEntity(CreateAirportDto createDto)
    {
        return new Airport
        {
            Name = createDto.Name,
            Code = createDto.Code,
            City = createDto.City,
            Country = createDto.Country
        };
    }

    public Airport MapToEntity(Guid id, CreateAirportDto createDto)
    {
        return new Airport
        {
            Id = id,
            Name = createDto.Name,
            Code = createDto.Code,
            City = createDto.City,
            Country = createDto.Country
        };
    }
}
