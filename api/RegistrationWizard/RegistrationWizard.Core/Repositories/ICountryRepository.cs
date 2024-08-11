using RegistrationWizard.Core.Entities;

namespace RegistrationWizard.Core.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
    Task<List<Province>> GetProvincesByCountryIdAsync(int countryId, CancellationToken cancellationToken);
}