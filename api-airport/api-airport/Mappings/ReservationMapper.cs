using api_airport.DTOs.Reservation;
using api_airport.Entity.Reservation;
using api_airport.Interfaces;

namespace api_airport.Mappings;

public class ReservationMapper : IMapper<Reservation, ReservationDto, CreateReservationDto>
{
    public ReservationDto MapToDto(Reservation entity)
    {
        return new ReservationDto
        {
            Id = entity.Id,
            FlightNumber = entity.Flight?.FlightNumber ?? "",
            UserId = entity.UserId,
            Status = entity.Status,
            ReservedAt = entity.ReservedAt,
            Passengers = entity.Passengers.Select(p => new PassengerDto
            {
                PassengerName = p.PassengerName,
                SeatNumber = p.SeatNumber
            }).ToList()
        };
    }

    public Reservation MapToEntity(CreateReservationDto createDto)
    {
        return new Reservation
        {
            FlightId = createDto.FlightId,
            Status = "Reserved",
            ReservedAt = DateTime.UtcNow,
            Passengers = createDto.Passengers.Select(p => new ReservationPassenger
            {
                PassengerName = p.PassengerName,
                SeatNumber = p.SeatNumber
            }).ToList()
        };
    }

    public Reservation MapToEntity(Guid id, CreateReservationDto createDto)
    {
        return new Reservation
        {
            Id = id,
            FlightId = createDto.FlightId,
            Status = "Reserved",
            ReservedAt = DateTime.UtcNow,
            Passengers = createDto.Passengers.Select(p => new ReservationPassenger
            {
                PassengerName = p.PassengerName,
                SeatNumber = p.SeatNumber
            }).ToList()
        };
    }
}
