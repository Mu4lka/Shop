using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Domain.ValueObjects;
using Solution.Host.Infrastructure.Store.Tables;


namespace Solution.Host.Infrastructure.Store.Repositories;

public class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CreateAsync(User newUser)
    {
        const string sql = $"INSERT INTO users() VALUES(@)";
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.ExecuteAsync(sql, newUser.ToTable());
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}
