namespace Solution.Host.Domain.ValueObjects;

/// <summary>
/// Полное имя
/// </summary>
public record FullName
{
    public FullName(string firstName, string surname, string? patronymic = null)
    {
        FirstName = firstName;
        Surname = surname;
        Patronymic = patronymic;
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }
}
