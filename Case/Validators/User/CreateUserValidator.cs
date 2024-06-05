using Case.DTOs;
using FluentValidation;

namespace Case.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Mail boş bırakılamaz.");
            RuleFor(u => u.BirthDate).LessThan(DateTime.Now);
        }
    }
}
