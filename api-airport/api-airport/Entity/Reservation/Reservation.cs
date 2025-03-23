using System.ComponentModel.DataAnnotations.Schema;

namespace api_airport.Entity.Reservation;

public class Reservation
{
    public Guid? Id { get; set; }

    [Column("flight_id")]
    public Guid FlightId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    public string? Status { get; set; }

    [Column("reserved_at")]
    public DateTime? ReservedAt { get; set; }

    public List<ReservationPassenger> Passengers { get; set; } = new();

    public virtual Flight.Flight Flight { get; set; } = null!;
}
