using api_airport.DTOs.Reservation;
using api_airport.Entity.Reservation;
using api_airport.Interfaces;
using api_airport.Repositories.Interfaces;
using api_airport.Services.Interfaces;

namespace api_airport.Services.ReservationService;

public class ReservationService : BaseService<Reservation, ReservationDto, CreateReservationDto>, IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IMapper<Reservation, ReservationDto, CreateReservationDto> _reservationMapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ReservationService(
        IReservationRepository reservationRepository, 
        IFlightRepository flightRepository,
        IMapper<Reservation, ReservationDto, CreateReservationDto> reservationMapper,
        IHttpContextAccessor httpContextAccessor
        )
        : base(reservationRepository, reservationMapper)
    {
        _reservationRepository = reservationRepository;
        _flightRepository = flightRepository;
        _reservationMapper = reservationMapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<List<ReservationDto>> GetListAsync()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
        var role = _userService.Role;

        if (role == "Admin")
        {
            var reservations = await _reservationRepository.GetListAsync();
            return reservations.Select(r => _reservationMapper.MapToDto(r)).ToList();
        }

        var reservationsForUser = await _reservationRepository.GetListForUserAsync(userId);
        return reservationsForUser.Select(r => _reservationMapper.MapToDto(r)).ToList();
    }

    public override async Task<ReservationDto?> GetItemAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetItemAsync(id);
        if (reservation == null)
        {
            return null;
        }

        var userId = _userService.UserId;
        var userRole = _userService.Role;

        if (reservation.UserId != userId && userRole != "Admin")
        {
            throw new UnauthorizedAccessException("You do not have permission to view this reservation.");
        }

        return _reservationMapper.MapToDto(reservation);
    }

    public override async Task<string> AddAsync(CreateReservationDto createDto)
    {
        var userId = _userService.UserId;

        using (var transaction = await _reservationRepository.BeginTransactionAsync())
        {
            try
            {
                var flight = await _flightRepository.GetFlightWithLockAsync(createDto.FlightId);
                if (flight == null || flight.AvailableSeats < createDto.Passengers.Count)
                {
                    throw new InvalidOperationException("Not enough seats available.");
                }

                flight.AvailableSeats -= createDto.Passengers.Count;
                await _flightRepository.UpdateAsync(flight.Id, flight);

                var reservation = new Reservation
                {
                    FlightId = createDto.FlightId,
                    UserId = userId,
                    Status = "Reserved",
                    ReservedAt = DateTime.UtcNow,
                    Passengers = createDto.Passengers.Select(p => new ReservationPassenger
                    {
                        PassengerName = p.PassengerName,
                        SeatNumber = p.SeatNumber
                    }).ToList()
                };

                var response = await _reservationRepository.AddAsync(reservation);
                await _reservationRepository.SaveChangesAsync();

                await transaction.CommitAsync();

                return response;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public override async Task DeleteAsync(Guid id)
    {
        using (var transaction = await _reservationRepository.BeginTransactionAsync())
        {
            try
            {
                var reservation = await _reservationRepository.GetItemAsync(id);
                if (reservation == null)
                {
                    throw new KeyNotFoundException("Reservation not found.");
                }

                var userId = _userService.UserId;
                var userRole = _userService.Role;

                if (reservation.UserId != userId && userRole != "Admin")
                {
                    throw new UnauthorizedAccessException("You do not have permission to delete this reservation.");
                }

                var flight = await _flightRepository.GetFlightWithLockAsync(reservation.FlightId);
                if (flight != null)
                {
                    flight.AvailableSeats += reservation.Passengers.Count;
                    await _flightRepository.UpdateAsync(flight.Id, flight);
                }

                await _reservationRepository.DeleteAsync(id);
                await _reservationRepository.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
