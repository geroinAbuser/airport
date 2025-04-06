namespace api_airport.User;

public class CurrentUser : ICurrentUser
{
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
}