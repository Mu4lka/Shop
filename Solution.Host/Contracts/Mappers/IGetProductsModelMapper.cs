using Solution.Host.Contracts.Mappers;
using Solution.Host.Domain.Entities;

namespace Solution.Host.Endpoints;

internal interface IGetProductsModelMapper : IModelMapper<ICollection<Product>>;

public class GetProductsModelMapper : IGetProductsModelMapper
{
    public object Map(ICollection<Product> input)
    {
        return input.Select(p => new
        {
            p.Id,
            p.Title,
            p.Description,
            p.AvailableQuantity,
            Sku = p.Sku.Code,
            Price = new
            {
                p.Price.Amount,
                p.Price.Currency
            }
        }).ToList();
    }
}