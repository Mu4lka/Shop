using System.ComponentModel.DataAnnotations;

namespace Solution.Host.Contracts;

internal class CreateOrderRequest
{
    [Length(1, int.MaxValue)]
    public ICollection<CreateOrderItemOrderDto> Items { get; set; } = default!;
}