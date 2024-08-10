using RegistrationWizard.Application.Commands.RegisterUser;
using RegistrationWizard.Application.Queries;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Infrastructure;
using RegistrationWizard.Infrastructure.Repositories;
using System.Text.Json.Serialization;

namespace RegistrationWizard.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();

            builder.Services.AddScoped<RegisterUserHandler>();
            builder.Services.AddScoped<GetCountriesQuery>();
            builder.Services.AddScoped<GetProvincesQuery>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
