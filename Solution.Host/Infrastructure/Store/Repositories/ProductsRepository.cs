using Dapper;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Infrastructure.Store.Tables;
using Solution.Host.Infrastructure.Store.Tables.Extensions;
using System.Data;

namespace Solution.Host.Infrastructure.Store.Repositories;

internal class ProductsRepository : BaseRepository, IProductsRepository
{
    public ProductsRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.QueryAsync<ProductTable>(
            "GetAllProducts",
            commandType: CommandType.StoredProcedure);

        return products.Select(p => p.ToProduct()).ToList();
    }

    public async Task<ICollection<Product>> GetByIdsAsync(ICollection<Guid> ids)
    {
        var idsString = string.Join(",", ids);
        using var connection = GetConnection();
        await connection.OpenAsync();
        var products = await connection.QueryAsync<ProductTable>(
            "GetProductsByIds",
            new { Ids = idsString },
            commandType: CommandType.StoredProcedure
            );

        return products.Select(p => p.ToProduct()).ToList();
    }
}
