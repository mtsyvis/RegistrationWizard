using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Commands.RegisterUser;

public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Login = request.Login,
            Password = request.Password,
            AgreeToTerms = request.AgreeToTerms,
            CountryId = request.CountryId,
            ProvinceId = request.ProvinceId
        };

        await userRepository.AddUserAsync(user, cancellationToken);

        return Result.Success();
    }

    public async Task HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Login = command.Login,
            Password = command.Password,
            AgreeToTerms = command.AgreeToTerms,
            CountryId = command.CountryId,
            ProvinceId = command.ProvinceId
        };

        await userRepository.AddUserAsync(user, cancellationToken);
    }
}
