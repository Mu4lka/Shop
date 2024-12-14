using Solution.Host.Domain.ValueObjects;
using System.Runtime.InteropServices;

namespace Solution.Host.Domain.Entities;

/// <summary>
/// Продукт
/// </summary>
public class Product : Entity
{
    private Product() { }

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; private set; } = default!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Доступное количество
    /// </summary>
    public int AvailableQuantity { get; private set; } = 0;

    /// <summary>
    /// Артикул
    /// </summary>
    public Sku Sku {  get; private set; }

    /// <summary>
    /// Цена
    /// </summary>
    public Price Price { get; private set; }

    public static Product Init(Guid id, string title, string description, int availableQuantity, Sku Sku, Price Price)
    {
        return new()
        {
            Id = id,
            Title = title,
            Description = description,
            AvailableQuantity = availableQuantity,
            Sku = Sku,
            Price = Price
        };
    }
}
