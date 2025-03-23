namespace api_airport.DTOs.Reservation;

public class CreateReservationDto
{
    public Guid FlightId { get; set; }

    public List<PassengerDto> Passengers { get; set; }
}
