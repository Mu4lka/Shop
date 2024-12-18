namespace Solution.Host.Contracts;

internal class UserRegisterRequest
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;

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
    public string Address { get; set; } = default!;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; } = default!;
}