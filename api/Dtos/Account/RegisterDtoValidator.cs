using api.Dtos.Account;
using FluentValidation;

namespace api.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Matches("^[^0-9]+$").WithMessage("Invalid UserName format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(email => email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^9\d{8}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.PIN)
                .NotEmpty().WithMessage("PIN is required.")
                .Matches(@"^\d{6}$").WithMessage("Invalid PIN format.");
        }
    }

}
