using Microsoft.AspNetCore.Mvc;
using Solution.Host.Contracts;
using Solution.Host.Domain.Entities;
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

    private static async Task<IResult> GetProductsAsync([FromServices] IProductsRepository productsRepository)
    {
        var products = await productsRepository.GetAllAsync();

        if (products.Count() == 0)
            return Results.NoContent();

        var body = products.Select(p => new GetProductDto()
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            AvailableQuantity = p.AvailableQuantity,
            Sku = p.Sku.Code,
            Price = new PriceDto()
            {
                Amount = p.Price.Amount,
                Currency = p.Price.Currency
            }
        }).ToList();

        return Results.Ok(ApiResponse.Ok(body));
    }
}
