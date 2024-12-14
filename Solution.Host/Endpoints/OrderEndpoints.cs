using Microsoft.AspNetCore.Mvc;
using Solution.Host.Contracts;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Endpoints.Services;
using Solution.Host.Utils;
using Solution.Host.Utils.Extensions;

namespace Solution.Host.Endpoints;

public static class OrderEndpoints
{
    public static void Map(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("")
            .WithTags("Заказы");

        group.MapPost("api/v1/orders", CreateOrderAsync)
            .WithSummary("Создать заказ");

        group.MapGet("api/v1/orders/my", GetMyOrdersAsync)
            .WithSummary("Получить мои заказы");
    }

    private static async Task<IResult> CreateOrderAsync(
        [FromServices] ICurrentUserProvider userProvider,
        [FromServices] IProductsRepository productsRepository,
        [FromServices] IOrdersRepository ordersRepository,
        [FromBody] CreateOrderRequest request)
    {
        var user = userProvider.Get();
        var products = await productsRepository.GetByIdsAsync(request.Items.Select(i => i.ProductId));

        Order.Create()

        if (result.Failure)
        {
            return Results.BadRequest(result.ToApiResponse());
        }

        await ordersRepository.CreateAsync(result.Data!);

        return Results.Created("", result.ToApiResponse());
    }

    private static async Task<IResult> GetMyOrdersAsync(
        [FromServices] ICurrentUserProvider userProvider,
        [FromServices] IProductsRepository productsRepository,
        [FromServices] IOrdersRepository ordersRepository)
    {
        var user = userProvider.Get();
        var orders = await ordersRepository.GetByCustomerId(user.Id);

        if (orders.Count() == 0)
            return Results.NoContent();

        var getOrdersBody = orders;

        return Results.Ok(ApiResponse.Ok(getOrdersBody));
    }
}