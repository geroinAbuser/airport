using api_airport.Services.Interfaces;

namespace api_airport.Services.Auth;

public class UserService : IUserService
{
    private Guid _userId;
    private string _username = string.Empty;
    private string _email = string.Empty;
    private string _role = string.Empty;

    public Guid UserId => _userId;
    public string Username => _username;
    public string Email => _email;
    public string Role => _role;

    public void SetUser(Guid userId, string username, string email, string role)
    {
        _userId = userId;
        _username = username;
        _email = email;
        _role = role;
    }
}
