using Case.Enums;

namespace Case.ViewModels
{
    public class UserViewModel 
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
}
