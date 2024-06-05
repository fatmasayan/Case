using Case.DTOs;
using FluentValidation;

namespace Case.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.BirthDate).LessThan(DateTime.Now);
            RuleFor(u => u.PhoneNumber).Matches(@"^\+\d{1,3}\s\d{1,14}(\s\d{1,13})?$");
            RuleFor(u => u.Gender).NotNull();
        }
    }
}
