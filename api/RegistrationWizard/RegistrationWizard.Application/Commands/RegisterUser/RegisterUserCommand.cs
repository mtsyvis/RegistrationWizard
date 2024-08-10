namespace RegistrationWizard.Application.Commands.RegisterUser;

public class RegisterUserCommand
{
    public string Login { get; set; }
    public string Password { get; set; }
    public bool AgreeToTerms { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }
}

