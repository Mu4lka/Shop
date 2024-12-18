using Solution.Host.Domain.Entities;

namespace Solution.Host.Contracts.Mappers;

public interface IGetMyOrdersModelMapper : IModelMapper<ICollection<Order>>;

public class GetMyOrdersModelMapper : IGetMyOrdersModelMapper
{
    public object Map(ICollection<Order> input)
    {
        return input.Select(o => new
        {
            o.Id,
            o.CreatedAt,
            o.Status,
            o.CustomerId.UserId,
            Items = o.Items.Select(i => new
            {
                i.Id,
                i.Count,
                Product = new { i.Product.Id, i.Product.Title },
                i.Price
            })
        }).ToList();
    }
}