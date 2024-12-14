namespace Solution.Host.Contracts;

public class PriceDto
{
    /// <summary>
    /// Колличество
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency { get; set; } = default!;
}