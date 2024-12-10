using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Infrastructure.Store.Tables;
using Solution.Host.Infrastructure.Store.Tables.Extensions;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CreateAsync(User newUser)
    {
        const string sql = """
        INSERT INTO Users (Id, FirstName, Surname, Patronymic, Email, PasswordHash, Address, PhoneNumber)
        VALUES (@Id, @FirstName, @Surname, @Patronymic, @Email, @PasswordHash, @Address, @PhoneNumber);
        """;
        using var connection = GetConnection();
        await connection.OpenAsync();
        await connection.ExecuteAsync(sql, newUser.ToTable());
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        const string sql = """
            SELECT * FROM Users WHERE Email = @Email
            """;

        using var connection = GetConnection();
        await connection.OpenAsync();
        var userTable = connection.QueryFirstOrDefault<UserTable>(sql, new { Email = email });

        return userTable?.ToUser();
    }
}
