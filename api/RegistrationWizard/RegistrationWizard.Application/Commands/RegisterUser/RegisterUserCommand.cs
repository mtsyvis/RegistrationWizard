using RegistrationWizard.Application.Abstractions.Messaging;

namespace RegistrationWizard.Application.Commands.RegisterUser;

public record RegisterUserCommand(
    string Login,
    string Password,
    bool AgreeToTerms,
    int CountryId,
    int ProvinceId) : ICommand;

