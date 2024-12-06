
namespace Solution.Host.Domain.ValueObjects;

public record Sku
{
    public string Code { get; set; }

    internal static Sku Create(string sku)
    {
        throw new NotImplementedException();
    }
}
