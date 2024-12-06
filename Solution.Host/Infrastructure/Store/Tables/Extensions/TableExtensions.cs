using Solution.Host.Domain.Entities;
using Solution.Host.Domain.ValueObjects;

namespace Solution.Host.Infrastructure.Store.Tables.Extensions;

internal static class TableExtensions
{
    public static Product ToProduct(this ProductTable source)
        => Product.Create(

            source.Title,
            source.Description,
            source.AvailableQuantity,
            Sku.Create(source.Sku),
            new Price(source.Amount, source.Currency));

    public static UserTable ToTable(this User source)
        => new UserTable()
        {
            Id 
        };
}
