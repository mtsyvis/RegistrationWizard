using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Application.Queries;

public class GetProvincesQuery
{
    private readonly ICountryRepository _countryRepository;

    public GetProvincesQuery(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<List<Province>> ExecuteAsync(int countryId)
    {
        return await _countryRepository.GetProvincesByCountryIdAsync(countryId);
    }
}
