using Solution.Host.Domain.Entities;

namespace Solution.Host.Domain.Interfaces.Repositories;

public interface IOrdersRepository
{
    Task CreateAsync(Order order);
    Task<ICollection<Order>> GetByCustomerId(Guid id);
}
