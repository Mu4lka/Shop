using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

public class UniqueOrderItems : UniqueСollection<OrderItem>
{
    private static Error CreationError = new Error("Ошибка создания уникальных элементов заказа.");

    private UniqueOrderItems(IEnumerable<OrderItem> orderItems) : base(orderItems) { }

    public static Result<UniqueOrderItems> Create(Guid orderId, ICollection<(int Coint, Product Product)> items)
    {
        var results = items.Select(i => OrderItem.CreateFromProduct(orderId, i.Product, i.Coint));

        if (results.Any(r => r.Failure))
        {
            return Result.Fail<UniqueOrderItems>(
                error: CreationError,
                innerErrors: results.Where(r => r.Failure).Select(r => r.Error).ToArray()!);
        }

        var uniqueOrderItems = new UniqueOrderItems(results.Select(r => r.Data!));

        if (items.Count <= 0)
        {
            return Result.Fail<UniqueOrderItems>(
                error: CreationError,
                innerErrors: new Error("Количество элементов заказа должно быть больше нуля"));
        }

        if (items.Count != results.Count())
        {
            return Result.Fail<UniqueOrderItems>(
                error: CreationError,
                innerErrors: new Error("Элементы заказа не уникальны"));
        }

        return uniqueOrderItems;
    }
}
