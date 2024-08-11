using FluentValidation;
using RegistrationWizard.Application.Commands.RegisterUser;

namespace RegistrationWizard.Application.Validations;

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
            .MaximumLength(50);

        RuleFor(x => x.AgreeToTerms)
            .Equal(true)
            .WithMessage("You must agree to the terms and conditions.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0);

        RuleFor(x => x.ProvinceId)
            .GreaterThan(0);
    }
}
