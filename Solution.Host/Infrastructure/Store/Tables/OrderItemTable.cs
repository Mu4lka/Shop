namespace Solution.Host.Infrastructure.Store.Tables;

public class OrderItemTable : Table
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Колличество
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency { get; set; } = default!;
}
