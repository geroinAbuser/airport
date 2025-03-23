using System.ComponentModel.DataAnnotations.Schema;

namespace api_airport.Entity.Flight;

public class Flight
{
    public Guid Id { get; set; }

    [Column("flight_number")]
    public string? FlightNumber { get; set; }

    [Column("departure_airport_id")]
    public Guid DepartureAirportId { get; set; }

    [Column("arrival_airport_id")]
    public Guid ArrivalAirportId { get; set; }

    [Column("airplane_id")]
    public Guid AirplaneId { get; set; }

    [Column("available_seats")]
    public int AvailableSeats { get; set; }

    [Column("departure_time")]
    public DateTime DepartureTime { get; set; }

    [Column("arrival_time")]
    public DateTime ArrivalTime { get; set; }

    public string? Status { get; set; }

    public virtual Airport.Airport DepartureAirport { get; set; } = null!;
    public virtual Airport.Airport ArrivalAirport { get; set; } = null!;
    public virtual Airplane.Airplane Airplane { get; set; } = null!;
}
