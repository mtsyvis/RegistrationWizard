using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Queries.GetCountries;

public class GetCountriesQueryHandler : IQueryHandler<GetCountriesQuery, List<Country>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountriesQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Result<List<Country>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetCountriesAsync(cancellationToken);
    }
}
