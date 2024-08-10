﻿namespace RegistrationWizard.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool AgreeToTerms { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }
}
