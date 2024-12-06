using Solution.Host.Domain.Entities;

namespace Solution.Host.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    Task CreateAsync(User newUser);
    Task<User?> GetByEmailAsync(string email);
}
