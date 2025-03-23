namespace api_airport.DTOs.Airplane;

public class AirplaneDto
{
    public Guid? Id { get; set; }

    public string? Model { get; set; }

    public int Capacity { get; set; }

    public string? AirportName { get; set; }

    public Guid? AirportId { get; set; }
}
