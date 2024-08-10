using RegistrationWizard.Core.Entities;

namespace RegistrationWizard.Core.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
}
