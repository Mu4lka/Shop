using System.ComponentModel.DataAnnotations;

namespace Solution.Host.Contracts;

public class UserRegistrationRequest
{
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Password { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Surname { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [StringLength(100, MinimumLength = 2)]
    public string? Patronymic { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Address { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}