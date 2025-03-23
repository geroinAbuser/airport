namespace api_airport.DTOs.Flight;

public class CreateFlightDto
{
    public string? FlightNumber { get; set; }
    public Guid DepartureAirportId { get; set; }
    public Guid ArrivalAirportId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public Guid AirplaneId { get; set; }
}
