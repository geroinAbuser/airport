using System.ComponentModel.DataAnnotations.Schema;

namespace api_airport.Entity.Reservation;

public class ReservationPassenger
{
    public Guid Id { get; set; }

    [Column("reservation_id")]
    public Guid ReservationId { get; set; }

    [Column("passenger_name")]
    public string PassengerName { get; set; }

    [Column("seat_number")]
    public int SeatNumber { get; set; }

    [Column("created_by")]
    public Guid CreatedBy { get; set; }
}
