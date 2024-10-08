﻿using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Infrastructure.Repositories;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await context.Countries.Include(c => c.Provinces).ToListAsync(cancellationToken);
    }

    public async Task<List<Province>> GetProvincesByCountryIdAsync(int countryId, CancellationToken cancellationToken)
    {
        return await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync(cancellationToken);
    }
}