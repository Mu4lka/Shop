namespace Solution.Host.Domain.ValueObjects;

/// <summary>
/// Цена
/// </summary>
public record Price
{
    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    /// <summary>
    /// Колличество
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency {  get; set; }
}
