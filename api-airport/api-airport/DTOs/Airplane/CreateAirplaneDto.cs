namespace api_airport.DTOs.Airplane;

public class CreateAirplaneDto
{
    public string? Model { get; set; }

    public int Capacity { get; set; }

    public Guid AirportId { get; set; }
}
