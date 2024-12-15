using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            .WithSummary("Создать заказ")
            .RequireAuthorization();

        group.MapGet("api/v1/orders/my", GetMyOrdersAsync)
            .WithSummary("Получить мои заказы")
            .RequireAuthorization();
    }

    private static async Task<IResult> CreateOrderAsync(
        [FromServices] ICurrentUserProvider userProvider,
        [FromServices] IProductsRepository productsRepository,
        [FromServices] IOrdersRepository ordersRepository,
        [FromServices] ILoggerFactory loggerFactory,
        [FromBody] CreateOrderRequest request)
    {
        var user = userProvider.Get();
        var products = await productsRepository.GetByIdsAsync(request.Items.Select(i => i.ProductId).ToList());

        var items = products.Join(request.Items, p => p.Id, i => i.ProductId, (p, i) => (i.Count, p));

        var orderId = Guid.NewGuid();

        var creationUniqueOrderItemsResult = OrderItemCollection.Create(orderId, items.ToList());

        if (creationUniqueOrderItemsResult.Failure)
        {
            return Results.BadRequest(creationUniqueOrderItemsResult.ToApiResponse());
        }

        var order = Order.Create(orderId, user.Id, creationUniqueOrderItemsResult.Data!);
        await ordersRepository.CreateAsync(order);

        return Results.Created("", order);
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