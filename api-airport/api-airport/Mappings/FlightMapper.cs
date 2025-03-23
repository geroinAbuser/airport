using api_airport.DTOs.Flight;
using api_airport.Entity.Flight;
using api_airport.Interfaces;

namespace api_airport.Mappings;

public class FlightMapper : IMapper<Flight, FlightDto, CreateFlightDto>
{
    public FlightDto MapToDto(Flight entity)
    {
        return new FlightDto
        {
            Id = entity.Id,
            FlightNumber = entity.FlightNumber,
            DepartureAirportName = entity.DepartureAirport?.Name, 
            DepartureAirportId = entity.DepartureAirportId,
            ArrivalAirportName = entity.ArrivalAirport?.Name,  
            ArrivalAirportId = entity.ArrivalAirportId,
            DepartureTime = entity.DepartureTime,
            ArrivalTime = entity.ArrivalTime,
            AirplaneModel = entity.Airplane?.Model,
            AirplaneId = entity.AirplaneId,
            Status = entity.Status,
            AvailableSeats = entity.AvailableSeats
        };
    }

    public Flight MapToEntity(CreateFlightDto createDto)
    {
        return new Flight
        {
            FlightNumber = createDto.FlightNumber,
            DepartureAirportId = createDto.DepartureAirportId,
            ArrivalAirportId = createDto.ArrivalAirportId,
            DepartureTime = createDto.DepartureTime,
            ArrivalTime = createDto.ArrivalTime,
            AirplaneId = createDto.AirplaneId
        };
    }

    public Flight MapToEntity(Guid id, CreateFlightDto createDto)
    {
        return new Flight
        {
            Id = id,
            FlightNumber = createDto.FlightNumber,
            DepartureAirportId = createDto.DepartureAirportId,
            ArrivalAirportId = createDto.ArrivalAirportId,
            DepartureTime = createDto.DepartureTime,
            ArrivalTime = createDto.ArrivalTime,
            AirplaneId = createDto.AirplaneId
        };
    }
}