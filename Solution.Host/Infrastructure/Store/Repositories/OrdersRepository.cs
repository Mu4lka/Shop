using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Domain.ValueObjects;
using Solution.Host.Infrastructure.Store.Tables;
using Solution.Host.Infrastructure.Store.Tables.Extensions;
using System.Data;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class OrdersRepository : BaseRepository, IOrdersRepository
{
    public OrdersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CreateAsync(Order order)
    {
        var orderTable = new OrderTable()
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Status = (int)order.Status,
            UserId = order.CustomerId.UserId,
        };

        var orderItems = order.Items.Select(
            o => new OrderItemTable()
            {
                Id = o.Id,
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Count = o.Count,
                Amount = o.Price.Amount,
                Currency = o.Price.Currency
            });

        using var connection = GetConnection();
        await connection.OpenAsync();
        using var transaction = await connection.BeginTransactionAsync();

        try
        {
            await connection.ExecuteAsync("CreateOrder", orderTable, transaction, commandType: CommandType.StoredProcedure);
            await connection.ExecuteAsync("CreateOrderItem", orderItems, transaction, commandType: CommandType.StoredProcedure);
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<ICollection<Order>> GetByUserId(CustomerId id)
    {
        using var connection = GetConnection();
        await connection.OpenAsync();

        var orders = new List<Order>();

        var results = await connection.QueryAsync<OrderTable, OrderItemTable, ProductTable, OrderTable>(
            "GetOrdersByUserId",
            (o, oi, p) =>
            {
                var order = orders.FirstOrDefault(order => order.Id == o.Id);

                if (order is not null)
                {
                    order.AddOrderItem(OrderItem.Init(oi.Id, oi.OrderId, p.ToProduct(), new Price(oi.Amount, oi.Currency), oi.Count));
                    return o;
                }

                orders.Add(
                    Order.Init(
                        o.Id,
                        o.UserId,
                        o.CreatedAt,
                        (OrderStatus)o.Status,
                        new OrderItemCollection(
                            [OrderItem.Init(oi.Id, oi.OrderId, p.ToProduct(),new Price(oi.Amount, oi.Currency), oi.Count)]
                            )));

                return o;
            },
            new { Id = id.UserId });

        return orders;
    }
}
