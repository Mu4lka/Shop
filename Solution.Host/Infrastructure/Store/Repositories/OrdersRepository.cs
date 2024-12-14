using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Domain.ValueObjects;
using Solution.Host.Infrastructure.Store.Tables;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class OrdersRepository : BaseRepository, IOrdersRepository
{
    public OrdersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CreateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Order>> GetByCustomerId(CustomerId id)
    {
        const string sql = "SELCT * FROM Orders o JOIN OrderItems oi ON o.Id = o.OrderId WHERE o.Id = @Id";

        using var connection = GetConnection();
        await connection.OpenAsync();
        var a = await connection.QueryAsync(sql, new { Id = id  });

        throw new NotImplementedException();
    }
}
