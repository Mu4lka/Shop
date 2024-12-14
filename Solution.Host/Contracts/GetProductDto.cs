namespace Solution.Host.Contracts;

public class GetProductDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Доступное количество
    /// </summary>
    public int AvailableQuantity { get; set; } = 0;

    /// <summary>
    /// Артикул
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public PriceDto Price { get; set; }
}
