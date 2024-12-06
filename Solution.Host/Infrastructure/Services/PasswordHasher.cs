using Solution.Host.Endpoints.Services;

namespace Solution.Host.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string ToHash(string password)
    {
        throw new NotImplementedException();
    }

    public bool Verify(string sourcePassword, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
