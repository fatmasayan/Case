using Case.DTOs;
using Case.Models;
using FluentValidation;

namespace Case.Validators.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Mail boş bırakılamaz/Düzgün mail giriniz.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
        }
    }
}
