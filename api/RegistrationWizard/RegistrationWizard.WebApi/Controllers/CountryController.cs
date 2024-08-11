using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Application.Queries.GetCountries;
using RegistrationWizard.Application.Queries.GetProvincesByCountryId;
using RegistrationWizard.WebApi.Abstractions;

namespace RegistrationWizard.WebApi.Controllers;

[Route("api/countries")]
public class CountryController : ApiController
{
    public CountryController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
    {

        var query = new GetCountriesQuery();
        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpGet("{countryId}/provinces")]
    public async Task<IActionResult> GetProvinces(int countryId, CancellationToken cancellationToken)
    {
        var query = new GetProvincesByCountryIdQuery(countryId);
        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }
}
