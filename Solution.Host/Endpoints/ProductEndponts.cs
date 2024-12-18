using Microsoft.AspNetCore.Mvc;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Utils;

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

    private static async Task<IResult> GetProductsAsync(
        [FromServices] IProductsRepository productsRepository,
        [FromServices] IGetProductsModelMapper mapper
        )
    {
        var products = await productsRepository.GetAllAsync();

        if (products.Count() == 0)
            return Results.NoContent();

        var body = mapper.Map(products);

        return Results.Ok(ApiResponse.Ok(body));
    }
}
