namespace api_airport.User;

public interface ICurrentUser
{
    Guid UserId { get; set; }
    string? Name { get; set; }
    string? Surname { get; set; }
    string? Role { get; set; }
    string? Email { get; set; }
}
