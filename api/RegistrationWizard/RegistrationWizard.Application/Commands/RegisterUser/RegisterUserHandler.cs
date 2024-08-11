using FluentValidation;
using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Commands.RegisterUser;

public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<RegisterUserCommand> _validator;

    public RegisterUserHandler(IUserRepository userRepository, IValidator<RegisterUserCommand> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var user = new User
        {
            Login = request.Login,
            Password = request.Password,
            AgreeToTerms = request.AgreeToTerms,
            CountryId = request.CountryId,
            ProvinceId = request.ProvinceId
        };

        await _userRepository.AddUserAsync(user, cancellationToken);

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

        await _userRepository.AddUserAsync(user, cancellationToken);
    }
}
