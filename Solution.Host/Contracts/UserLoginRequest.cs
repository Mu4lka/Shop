using System.ComponentModel.DataAnnotations;

namespace Solution.Host.Contracts;

internal class UserLoginRequest
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}