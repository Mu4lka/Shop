namespace Solution.Host.Domain.Entities;

public enum OrderStatus
{
    /// <summary>
    /// Создана
    /// </summary>
    Created = 0,

    /// <summary>
    /// Отправлена
    /// </summary>
    Sent,

    /// <summary>
    /// В пункте выдачи
    /// </summary>
    PointOfIssue,

    /// <summary>
    /// Получена
    /// </summary>
    Received
}