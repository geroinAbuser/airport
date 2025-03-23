using api_airport.DTOs.Flight;
using api_airport.Entity.Flight;
using api_airport.Interfaces;
using api_airport.Repositories.Interfaces;
using api_airport.Services.Interfaces;

namespace api_airport.Services.FlightService;

public class FlightService : BaseService<Flight, FlightDto, CreateFlightDto>, IFlightService
{
    private readonly IAirplaneRepository _airplaneRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IMapper<Flight, FlightDto, CreateFlightDto> _flightMapper;
    public FlightService(IAirplaneRepository airplaneRepository, IFlightRepository flightRepository, IMapper<Flight, FlightDto, CreateFlightDto> flightMapper)
        : base(flightRepository, flightMapper)
    {
        _airplaneRepository = airplaneRepository;
        _flightRepository = flightRepository;
        _flightMapper = flightMapper;
    }

    public override async Task<List<FlightDto>> GetListAsync()
    {
        var flights = await _flightRepository.GetListAsync();
        return flights.Select(f => _flightMapper.MapToDto(f)).ToList();
    }

    public override async Task<FlightDto?> GetItemAsync(Guid id)
    {
        var flight = await _flightRepository.GetItemAsync(id);
        if (flight == null)
        {
            return null;
        }

        return _flightMapper.MapToDto(flight);
    }

    public override async Task UpdateAsync(Guid id, CreateFlightDto updateDto)
    {
        var airplane = await _airplaneRepository.GetItemAsync(updateDto.AirplaneId);

        var flight = _flightMapper.MapToEntity(id, updateDto);

        flight.AvailableSeats = airplane.Capacity;

        await _flightRepository.UpdateAsync(id, flight);
    }

    public override async Task<string> AddAsync(CreateFlightDto createDto)
    {
        var airplane = await _airplaneRepository.GetItemAsync(createDto.AirplaneId);

        var flight = _flightMapper.MapToEntity(createDto);

        flight.AvailableSeats = airplane.Capacity;

        return await _flightRepository.AddAsync(flight);
    }
}
