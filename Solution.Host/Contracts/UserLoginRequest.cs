using System.ComponentModel.DataAnnotations;

namespace Solution.Host.Contracts;

internal class UserLoginRequest
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
}