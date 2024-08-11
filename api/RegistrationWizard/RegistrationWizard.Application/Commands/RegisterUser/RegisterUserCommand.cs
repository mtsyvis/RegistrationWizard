using RegistrationWizard.Application.Abstractions.Messaging;

namespace RegistrationWizard.Application.Commands.RegisterUser;

public class RegisterUserCommand : ICommand
{
    public string Login { get; set; }
    public string Password { get; set; }
    public bool AgreeToTerms { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }
}

