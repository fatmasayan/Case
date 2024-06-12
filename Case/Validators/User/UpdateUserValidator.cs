using Case.DTOs;
using FluentValidation;

namespace Case.Validators.User;

public class UpdateUserValidator : AbstractValidator<UpdateUser>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
        RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
        RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Mail boş bırakılamaz/Düzgün mail giriniz.");
        RuleFor(u => u.BirthDate).LessThan(DateTime.Now).WithMessage("Doğum Tarihi bugünden büyük olamaz.");
        RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("Telefon boş bırakılamaz.");
        RuleFor(u => u.Gender).NotNull();
    }
}
