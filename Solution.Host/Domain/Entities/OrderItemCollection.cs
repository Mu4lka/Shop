using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

public class OrderItemCollection : UniqueСollection<OrderItem>
{
    private static Error CreationError = new Error("Ошибка создания элементов заказа.");

    public OrderItemCollection(IEnumerable<OrderItem> orderItems) : base(orderItems) { }

    public static Result<OrderItemCollection> Create(Guid orderId, ICollection<(int Coint, Product Product)> items)
    {
        if (items.Count <= 0)
        {
            return Result.Fail<OrderItemCollection>(
                error: CreationError,
                innerErrors: new Error("Количество элементов заказа должно быть больше нуля"));
        }

        var results = items.Select(i => OrderItem.CreateFromProduct(orderId, i.Product, i.Coint));

        if (results.Any(r => r.Failure))
        {
            return Result.Fail<OrderItemCollection>(
                error: CreationError,
                innerErrors: results.Where(r => r.Failure).Select(r => r.Error).ToArray()!);
        }

        var uniqueOrderItems = new OrderItemCollection(results.Select(r => r.Data!));

        if (items.Count != results.Count())
        {
            return Result.Fail<OrderItemCollection>(
                error: CreationError,
                innerErrors: new Error("Элементы заказа не уникальны"));
        }

        return uniqueOrderItems;
    }
}
