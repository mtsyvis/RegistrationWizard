namespace RegistrationWizard.Core.Entities;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public bool AgreeToTerms { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }

    public Country Country { get; set; }
    public Province Province { get; set; }
}
