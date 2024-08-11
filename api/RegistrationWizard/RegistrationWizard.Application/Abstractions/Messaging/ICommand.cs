using MediatR;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
