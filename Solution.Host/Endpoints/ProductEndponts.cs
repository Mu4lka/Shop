using Microsoft.AspNetCore.Mvc;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;

namespace Solution.Host.Endpoints;

public static class ProductEndponts
{
    public static void Map(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("")
            .WithTags("Продукты")
            .RequireAuthorization();

        group.MapGet("api/v1/products", GetProductsAsync)
            .WithSummary("Получить все продукты");
    }

    private static async Task<IResult> GetProductsAsync([FromServices] IProductsRepository productsRepository)
    {
        ICollection<Product> products = await productsRepository.GetAllAsync();

        if (products.Count() == 0)
            return Results.NoContent();

        return Results.Ok(products);
    }
}
