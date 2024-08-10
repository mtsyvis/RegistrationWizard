using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Application.Queries;

public class GetCountriesQuery
{
    private readonly ICountryRepository _countryRepository;

    public GetCountriesQuery(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<List<Country>> ExecuteAsync()
    {
        return await _countryRepository.GetCountriesAsync();
    }
}