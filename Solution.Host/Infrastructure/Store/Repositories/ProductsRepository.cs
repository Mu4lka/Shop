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

    public async Task<ICollection<Product>> GetByIdsAsync(ICollection<Guid> ids)
    {
        var idsString = string.Join(",", ids);

        // SQL-запрос с использованием STRING_SPLIT
        const string sql = @"
        SELECT * 
        FROM products 
        WHERE id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))";
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.QueryAsync<ProductTable>(sql, new { Ids = idsString });

        return products.Select(p => p.ToProduct()).ToList();
    }
}
