using System.ComponentModel.DataAnnotations.Schema;

namespace api_airport.Entity.Airplane;

public class Airplane
{
    public Guid? Id { get; set; }

    public string? Model { get; set; }

    public int Capacity { get; set; }

    [ForeignKey("Airport")]
    [Column("airport_id")]
    public Guid AirportId { get; set; }

    public virtual Airport.Airport Airport { get; set; } = null!;
}
