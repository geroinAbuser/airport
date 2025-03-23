namespace api_airport.Services.Interfaces;

public interface IUserService
{
    Guid UserId { get; }
    string Username { get; }
    string Email { get; }
    string Role { get; }
    void SetUser(Guid userId, string username, string email, string role);
}
