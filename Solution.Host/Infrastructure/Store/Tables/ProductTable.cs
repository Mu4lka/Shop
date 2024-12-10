namespace Solution.Host.Infrastructure.Store.Tables;

public class ProductTable : Table
{
    
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
    public int AvailableQuantity { get; set; }

    /// <summary>
    /// Артикул
    /// </summary>
    public string Sku { get; set; } = default!;

    /// <summary>
    /// Колличество
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency { get; set; } = default!;
}
