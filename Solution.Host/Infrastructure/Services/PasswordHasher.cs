using Solution.Host.Endpoints.Services;
using Crypt = BCrypt.Net.BCrypt;

namespace Solution.Host.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string ToHash(string password) => Crypt.HashPassword(password);

    public bool Verify(string sourcePassword, string passwordHash) => Crypt.Verify(sourcePassword, passwordHash);
}