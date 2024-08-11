using MediatR;
using RegistrationWizard.Core.Shared;

namespace RegistrationWizard.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}