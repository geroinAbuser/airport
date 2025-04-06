using api_identity.DTOs;
using api_identity.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly TokenService _tokenService;

    public AuthController(AuthService authService, TokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _authService.RegisterAsync(dto.Name, dto.Surname, dto.Email, dto.Password);
        return Ok("Registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _authService.LoginAsync(dto.Email, dto.Password);
        if (user == null) return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token });
    }
}
