using FluentValidation;
using RegistrationWizard.Application.Abstractions.Messaging;
using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;
using RegistrationWizard.Core.Shared;
using System.Security.Cryptography;
using System.Text;

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

        // todo: add check if user with the same email already exists

        var user = new User
        {
            Login = request.Login,
            Password = HashPassword(request.Password),
            AgreeToTerms = request.AgreeToTerms,
            CountryId = request.CountryId,
            ProvinceId = request.ProvinceId
        };

        await _userRepository.AddUserAsync(user, cancellationToken);

        return Result.Success();
    }

    // todo: move to a separate service
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
