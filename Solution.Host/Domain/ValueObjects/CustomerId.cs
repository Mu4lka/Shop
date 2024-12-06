namespace Solution.Host.Domain.ValueObjects;

/// <summary>
/// Идентификатор заказчика то есть пользователя
/// </summary>
public record CustomerId
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    public static implicit operator CustomerId(Guid userId)
    {
        return new CustomerId(userId);
    }
}
