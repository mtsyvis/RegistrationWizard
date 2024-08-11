using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Queries.GetProvincesByCountryId;

public class GetProvincesByCountryIdQueryHandler : IQueryHandler<GetProvincesByCountryIdQuery, List<Province>>
{
    private readonly ICountryRepository _countryRepository;

    public GetProvincesByCountryIdQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Result<List<Province>>> Handle(GetProvincesByCountryIdQuery request, CancellationToken cancellationToken)
    {
        // todo: implement the logic to check if country exists

        var provinces = await _countryRepository.GetProvincesByCountryIdAsync(request.CountryId, cancellationToken);

        return provinces;
    }
}
