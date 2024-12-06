namespace Solution.Host.Endpoints.Services;

internal interface IPasswordHasher
{
    string ToHash(string password);
    bool Verify(string sourcePassword, string passwordHash);
}