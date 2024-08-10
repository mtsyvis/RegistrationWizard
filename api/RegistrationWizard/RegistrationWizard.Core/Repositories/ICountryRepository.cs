using RegistrationWizard.Core.Entities;

namespace RegistrationWizard.Core.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync();
    Task<List<Province>> GetProvincesByCountryIdAsync(int countryId);
}