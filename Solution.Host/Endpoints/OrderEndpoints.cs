using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Solution.Host.Contracts;
using Solution.Host.Contracts.Mappers;
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
        [FromServices] IValidator<CreateOrderRequest> validator,
        [FromBody] CreateOrderRequest request)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        var user = userProvider.Get();
        var products = await productsRepository.GetByIdsAsync(request.Items.Select(i => i.ProductId).ToList());

        if (products.Count != request.Items.Count)
        {
            return Results.BadRequest(ApiResponse.Fail(
                new ApiError("Ошибка создания заказа!"),
                [new ApiError("Были выбраны не существующие продукты")]));
        }

        var items = products.Join(request.Items, p => p.Id, d => d.ProductId, (p, d) => (d.Count, p));
        var orderId = Guid.NewGuid();

        var result = OrderItemCollection.Create(orderId, items.ToList());

        if (result.Failure)
        {
            return Results.BadRequest(result.ToApiResponse());
        }

        var order = Order.Create(orderId, user.Id, result.Data!);
        await ordersRepository.CreateAsync(order);

        return Results.Created("", order.Id);
    }

    private static async Task<IResult> GetMyOrdersAsync(
        [FromServices] ICurrentUserProvider userProvider,
        [FromServices] IProductsRepository productsRepository,
        [FromServices] IGetMyOrdersModelMapper mapper,
        [FromServices] IOrdersRepository ordersRepository)
    {
        var user = userProvider.Get();
        var orders = await ordersRepository.GetByUserId(user.Id);

        if (orders.Count == 0)
            return Results.NoContent();

        var models = mapper.Map(orders);
        return Results.Ok(ApiResponse.Ok(models));
    }
}