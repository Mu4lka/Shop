
namespace Solution.Host.Domain.ValueObjects;

public record Sku
{
    private Sku() { }

    public string Code { get; private set; }

    public static Sku Create(string sku)
    {
        return new Sku() { Code = sku };
    }
}
