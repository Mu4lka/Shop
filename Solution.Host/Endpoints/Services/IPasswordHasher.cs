namespace Solution.Host.Endpoints.Services;

internal interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string sourcePassword, string passwordHash);
}