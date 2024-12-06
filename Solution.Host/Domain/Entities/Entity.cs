namespace Solution.Host.Domain.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; protected set; }
}
