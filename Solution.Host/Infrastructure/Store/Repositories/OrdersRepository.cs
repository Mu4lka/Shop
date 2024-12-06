using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;

namespace Solution.Host.Infrastructure.Store.Repositories;

public class OrdersRepository : IOrdersRepository
{
    public Task CreateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Order>> GetByCustomerId(Guid id)
    {
        throw new NotImplementedException();
    }
}
