using FluentValidation;
using RegistrationWizard.Application.Commands.RegisterUser;

namespace RegistrationWizard.Application.Validators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(50);


        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(50)
            .Matches(@"^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
            .WithMessage("Password must contain at least 1 digit and 1 letter.");

        RuleFor(x => x.AgreeToTerms)
            .Equal(true)
            .WithMessage("You must agree to the terms and conditions.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0);

        RuleFor(x => x.ProvinceId)
            .GreaterThan(0);
    }
}
