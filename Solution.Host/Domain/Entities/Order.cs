using Solution.Host.Domain.ValueObjects;
using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

/// <summary>
/// Заказ
/// </summary>
public class Order : Entity
{
    private Order() { }

    /// <summary>
    /// Идентификатор заказчика
    /// </summary>
    public CustomerId CustomerId { get; private set; }

    /// <summary>
    /// Создан в
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Статус
    /// </summary>
    public OrderStatus Status { get; private set; }

    /// <summary>
    /// Элементы заказа
    /// </summary>
    public HashSet<OrderItem> Items { get; private set; }

    /// <summary>
    /// Добавить новый элемент в заказ
    /// </summary>
    /// <param name="item"></param>
    public bool AddOrderItem(OrderItem item)
        => Items.Add(item);

    /// <summary>
    /// Создать
    /// </summary>
    public static Order Create(Guid id, CustomerId customerId, DateTime createdAt, OrderStatus status, HashSet<OrderItem> items)
        => new()
        {
            Id = id,
            CustomerId = customerId,
            CreatedAt = createdAt,
            Status = status,
            Items = items.ToHashSet(),
        };

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    public static Result<Order> CreateNew(Guid userId, ICollection<(int Count, Product Product)> items)
    {
        if (items.Count < 1)
        {
            return new Error("Ошибка создания заказа. Нужен хотя бы один продукт", "CREATE_ORDER_400_2");
        }

        var uniqueProductsCount = items.Select(i => i.Product.Id).ToHashSet().Count;

        if (uniqueProductsCount != items.Count)
        {
            return new Error("Ошибка создания заказа. Содержатся неуникальные продукты", "CREATE_ORDER_400_0");
        }

        var orderId = Guid.NewGuid();

        var results = items.Select(i => OrderItem.CreateFromProduct(orderId, i.Product, i.Count));

        if (results.Any(r => r.Failure))
        {
            return new Result<Order>()
            {
                Success = false,
                Error = new Error("Ошибка создания заказа", "CREATE_ORDER_400_1"),
                Errors = results.Where(r => r.Failure).Select(r => r.Error).ToArray()!
            };
        }

        var order = new Order()
        {
            Id = orderId,
            CustomerId = userId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Created,
            Items = results.Select(r => r.Data).ToHashSet()!
        };
        return order;
    }
}
