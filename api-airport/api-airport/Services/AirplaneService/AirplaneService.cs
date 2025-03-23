using api_airport.DTOs.Airplane;
using api_airport.Entity.Airplane;
using api_airport.Interfaces;
using api_airport.Repositories.Interfaces;
using api_airport.Services.Interfaces;

namespace api_airport.Services;

public class AirplaneService : BaseService<Airplane, AirplaneDto, CreateAirplaneDto>, IAirplaneService
{
    private readonly IAirplaneRepository _airplaneRepository;
    private readonly IMapper<Airplane, AirplaneDto, CreateAirplaneDto> _airplaneMapper;
    public AirplaneService(IAirplaneRepository airplaneRepository, IMapper<Airplane, AirplaneDto, CreateAirplaneDto> airplaneMapper)
        : base(airplaneRepository, airplaneMapper)
    {
        _airplaneRepository = airplaneRepository;
        _airplaneMapper = airplaneMapper;
    }

    public override async Task<List<AirplaneDto>> GetListAsync()
    {
        var airplanes = await _airplaneRepository.GetListAsync();  
        return airplanes.Select(a => _airplaneMapper.MapToDto(a)).ToList(); 
    }

    public override async Task<AirplaneDto?> GetItemAsync(Guid id)
    {
        var airplane = await _airplaneRepository.GetItemAsync(id); 
        return _airplaneMapper.MapToDto(airplane);
    }
}
