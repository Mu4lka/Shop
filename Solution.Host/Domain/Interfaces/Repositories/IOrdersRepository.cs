using Solution.Host.Domain.Entities;
using Solution.Host.Domain.ValueObjects;

namespace Solution.Host.Domain.Interfaces.Repositories;

public interface IOrdersRepository
{
    Task CreateAsync(Order order);
    Task<ICollection<Order>> GetByUserId(CustomerId id);
}
