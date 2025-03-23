namespace api_airport.DTOs.Flight;

public class FlightDto
{
    public Guid Id { get; set; }
    public string? FlightNumber { get; set; }
    public string? DepartureAirportName { get; set; }
    public Guid DepartureAirportId { get; set; }
    public string? ArrivalAirportName { get; set; }
    public Guid ArrivalAirportId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string? AirplaneModel { get; set; }
    public Guid AirplaneId { get; set; }
    public string? Status { get; set; }
    public int AvailableSeats { get; set; }
}

