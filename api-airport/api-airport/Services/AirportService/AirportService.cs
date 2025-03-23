using api_airport.DTOs.Airport;
using api_airport.Entity.Airport;
using api_airport.Interfaces;
using api_airport.Repositories.Interfaces;
using api_airport.Services.Interfaces;

namespace api_airport.Services.AirportService;

public class AirportService : BaseService<Airport, AirportDto, CreateAirportDto>, IAirportService
{
    private readonly IAirportRepository _airportRepository;
    private readonly IMapper<Airport, AirportDto, CreateAirportDto> _airportMapper;
    public AirportService(IAirportRepository airportRepository, IMapper<Airport, AirportDto, CreateAirportDto> airportMapper)
        : base(airportRepository, airportMapper)
    {
        _airportRepository = airportRepository;
        _airportMapper = airportMapper;
    }
}
