namespace Solution.Host.Contracts;

internal class CreateOrderRequest
{
    public ICollection<CreateOrderItemOrderDto> Items { get; set; } = default!;
}