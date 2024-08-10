using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Application.Queries;

namespace RegistrationWizard.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly GetCountriesQuery _getCountriesQuery;
    private readonly GetProvincesQuery _getProvincesQuery;

    public CountryController(GetCountriesQuery getCountriesQuery, GetProvincesQuery getProvincesQuery)
    {
        _getCountriesQuery = getCountriesQuery;
        _getProvincesQuery = getProvincesQuery;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _getCountriesQuery.ExecuteAsync();
        return Ok(countries);
    }

    [HttpGet("{countryId}/provinces")]
    public async Task<IActionResult> GetProvinces(int countryId)
    {
        var provinces = await _getProvincesQuery.ExecuteAsync(countryId);
        return Ok(provinces);
    }
}
