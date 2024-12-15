using Solution.Host.Domain.Entities;

namespace Solution.Host.Domain.Interfaces.Repositories;

public interface IProductsRepository
{
    Task<ICollection<Product>> GetAllAsync();
    Task<ICollection<Product>> GetByIdsAsync(ICollection<Guid> ids);
}
