using Case.Enums;

namespace Case.DTOs;

public class UpdateUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType? Gender { get; set; }
    public string? PhoneNumber { get; set; }
}
