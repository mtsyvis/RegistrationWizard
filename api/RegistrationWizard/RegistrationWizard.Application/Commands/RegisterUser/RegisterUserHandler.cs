using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Application.Commands.RegisterUser;

public class RegisterUserHandler(IUserRepository userRepository)
{
    public async Task HandleAsync(RegisterUserCommand command)
    {
        var user = new User
        {
            Login = command.Login,
            Password = command.Password,
            AgreeToTerms = command.AgreeToTerms,
            CountryId = command.CountryId,
            ProvinceId = command.ProvinceId
        };

        await userRepository.AddUserAsync(user);
    }
}
