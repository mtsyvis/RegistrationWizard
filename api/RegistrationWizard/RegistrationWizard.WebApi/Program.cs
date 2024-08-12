using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Infrastructure;
using RegistrationWizard.Infrastructure.Repositories;
using RegistrationWizard.WebApi.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddValidatorsFromAssembly(RegistrationWizard.Application.AssemblyReference.Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(RegistrationWizard.Application.AssemblyReference.Assembly));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

// Migrate the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseAuthorization();


app.MapControllers();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();
