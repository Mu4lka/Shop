using Solution.Host.Domain.ValueObjects;
using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

/// <summary>
/// Заказ
/// </summary>
public class Order : Entity
{
    private OrderItemCollection _orderItems;

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
    public ICollection<OrderItem> Items => [.. _orderItems];

    /// <summary>
    /// Создать
    /// </summary>
    public static Order Init(Guid id, CustomerId customerId, DateTime createdAt, OrderStatus status, OrderItemCollection items)
        => new()
        {
            Id = id,
            CustomerId = customerId,
            CreatedAt = createdAt,
            Status = status,
            _orderItems = items,
        };

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    public static Order Create(Guid orderId, Guid userId, OrderItemCollection items)
    {
        return Init(orderId, userId, DateTime.UtcNow, OrderStatus.Created, items);
    }

    /// <summary>
    /// Добавить элемент к заказу
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool AddOrderItem(OrderItem item)
        => _orderItems.Add(item);
}
