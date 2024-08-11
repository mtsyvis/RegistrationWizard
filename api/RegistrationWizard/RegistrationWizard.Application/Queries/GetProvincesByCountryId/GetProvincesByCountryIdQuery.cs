using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;

namespace RegistrationWizard.Application.Queries.GetProvincesByCountryId;

public record GetProvincesByCountryIdQuery(int CountryId) : IQuery<List<Province>>;
