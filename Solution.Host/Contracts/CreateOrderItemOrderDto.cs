namespace Solution.Host.Contracts;

internal class CreateOrderItemOrderDto
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}