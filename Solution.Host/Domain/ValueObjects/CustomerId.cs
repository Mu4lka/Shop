namespace Solution.Host.Domain.ValueObjects;

/// <summary>
/// Идентификатор заказчика то есть пользователя
/// </summary>
public record CustomerId
{
    public CustomerId(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; private set; }

    public static implicit operator CustomerId(Guid userId)
    {
        return new CustomerId(userId);
    }
}
