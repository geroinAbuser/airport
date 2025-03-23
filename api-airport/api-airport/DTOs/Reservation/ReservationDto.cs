namespace api_airport.DTOs.Reservation;

public class ReservationDto
{
    public Guid? Id { get; set; }

    public string FlightNumber { get; set; }

    public Guid UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? ReservedAt { get; set; }

    public List<PassengerDto> Passengers { get; set; } = new();
}
