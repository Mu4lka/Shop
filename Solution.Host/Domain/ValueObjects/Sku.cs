
namespace Solution.Host.Domain.ValueObjects;

/// <summary>
/// Артикул
/// </summary>
public record Sku
{
    private Sku() { }

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; private set; }

    public static Sku Create(string sku)
    {
        return new Sku() { Code = sku };
    }
}
