using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal interface IRepository
{
    DbConnection GetConnection();
}

internal abstract class BaseRepository : IRepository
{
    private readonly string _connection;

    public BaseRepository(IConfiguration configuration)
    {
        string name = "DatabaseMsSql";
        _connection = configuration.GetConnectionString(name) ??
            throw new ArgumentNullException(name, "Connection string is empty");
    }

    public DbConnection GetConnection()
        => new SqlConnection(_connection);
}
