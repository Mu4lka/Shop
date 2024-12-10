namespace Solution.Host.Infrastructure.Store.Tables;

public class OrderTable : Table
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Создан в
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public int Status { get; set; }
}
