using api_airport.Entity.Airplane;
using api_airport.Entity.Airport;
using api_airport.Entity.Flight;
using api_airport.Entity.Reservation;
using Microsoft.EntityFrameworkCore;

namespace api_airport.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationPassenger> ReservationPassengers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("main");
    }
}
