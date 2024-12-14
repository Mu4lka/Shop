using Solution.Host.Utils;

namespace Solution.Host.Domain.Entities;

public class UniqueOrderItems : UniqueСollection<OrderItem>
{
    public static Result<UniqueOrderItems> Create(IEnumerable<OrderItem> orderItems)
    {
        return default!;
    }
}
