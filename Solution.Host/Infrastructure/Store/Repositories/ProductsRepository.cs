using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Infrastructure.Store.Tables;
using Solution.Host.Infrastructure.Store.Tables.Extensions;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class ProductsRepository : BaseRepository, IProductsRepository
{
    public ProductsRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        const string sql = "SELECT * FROM products";
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.QueryAsync<ProductTable>(sql);

        return products.Select(p => p.ToProduct()).ToList();
    }

    public async Task<ICollection<Product>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        const string sql = $"SELECT * FROM products WHERE id IN (@Ids)";
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.QueryAsync<ProductTable>(sql, new { Ids = ids });

        return products.Select(p => p.ToProduct()).ToList();
    }
}
