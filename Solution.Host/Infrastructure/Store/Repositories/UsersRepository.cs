using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Infrastructure.Store.Tables;
using Solution.Host.Infrastructure.Store.Tables.Extensions;
using System.Data;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CreateAsync(User newUser)
    {
        using var connection = GetConnection();
        await connection.OpenAsync();
        await connection.ExecuteAsync(
            "CreateUser",
            newUser.ToTable(),
            commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        using var connection = GetConnection();
        await connection.OpenAsync();
        var userTable = connection.QueryFirstOrDefault<UserTable>(
            "GetUserByEmail",
            new { Email = email },
            commandType: CommandType.StoredProcedure);

        return userTable?.ToUser();
    }
}
