using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Application.Queries.GetCountries;

public record GetCountriesQuery : IQuery<List<Country>>;