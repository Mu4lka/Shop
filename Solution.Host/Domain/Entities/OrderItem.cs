using Solution.Host.Domain.ValueObjects;
using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

/// <summary>
/// Элемент заказа
/// </summary>
public class OrderItem : Entity
{
    private OrderItem(Guid id, Guid orderId, Product product, Price price, int productCount)
    {
        Id = id;
        OrderId = orderId;
        ProductId = product.Id;
        Product = product;
        Count = productCount;
        Price = price;
    }

    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; private set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Продукт
    /// </summary>
    public Product Product { get; private set; }

    /// <summary>
    /// Количество продукта
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Цена за продукт когда был оформлен заказ
    /// </summary>
    public Price Price { get; private set; } = default!;

    /// <summary>
    /// Создать
    /// </summary>
    public static OrderItem Create(Guid id, Guid orderId, Product product, Price price, int productCount)
    {
        return new OrderItem(id, orderId, product, price, productCount);
    }

    /// <summary>
    /// Создать элемент заказа на основе продукта
    /// </summary>
    public static Result<OrderItem?> CreateFromProduct(Guid orderId, Product product, int productCount)
    {
        if (productCount <= 0)
            return new Error($"Количество выбранных продуктов с названием {product.Title} должно быть больше нуля");

        if (productCount > product.AvailableQuantity)
            return new Error($"Количество выбранных продуктов с названием {product.Title} больше чем доступных. Всего доступно - {product.AvailableQuantity}");

        return new OrderItem(Guid.NewGuid(), orderId, product, product.Price, productCount);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OrderId, ProductId);
    }
}
