using Solution.Host.Contracts;
using Solution.Host.Domain.ValueObjects;

namespace Solution.Host.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : Entity
{
    private User() { }

    /// <summary>
    /// Емаил
    /// </summary>
    public string Email { get; private set; } = string.Empty;
    
    /// <summary>
    /// Хэш пароля
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;

    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; private set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; private set;  }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Создать пользователя
    /// </summary>
    public static User Create(Guid id, string email, string passwordHash, FullName fullName, string address, string phoneNumber)
        => new()
        {
            Id = id,
            Email = email,
            PasswordHash = passwordHash,
            FullName = fullName,
            Address = address,
            PhoneNumber = phoneNumber,
        };
}
