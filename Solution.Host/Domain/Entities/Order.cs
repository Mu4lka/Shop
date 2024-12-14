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
    public CustomerId CustomerId { get; private set; } = default!;

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
    /// Создать
    /// </summary>
    public static Order Init(Guid id, CustomerId customerId, DateTime createdAt, OrderStatus status, HashSet<OrderItem> items)
        => new()
        {
            Id = id,
            CustomerId = customerId,
            CreatedAt = createdAt,
            Status = status,
            Items = items,
        };

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    public static Result<Order> Create(Guid userId, HashSet<OrderItem> items)
    {
        return Init(Guid.NewGuid(), userId, DateTime.UtcNow, OrderStatus.Created, items);
    }
}
