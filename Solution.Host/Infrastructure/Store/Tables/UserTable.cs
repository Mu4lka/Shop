using Solution.Host.Domain.ValueObjects;

namespace Solution.Host.Infrastructure.Store.Tables;

public class UserTable
{
    /// <summary>
    /// Емаил
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Хэш пароля
    /// </summary>
    public string PasswordHash { get; set; } = default!;

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; private set; } = default!;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; private set; } = default!;
}
