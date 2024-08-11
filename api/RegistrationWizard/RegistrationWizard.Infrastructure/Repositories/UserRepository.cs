using RegistrationWizard.Core.Entities;
using RegistrationWizard.Core.Repositories;

namespace RegistrationWizard.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}