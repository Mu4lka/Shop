namespace Solution.Host.Endpoints.Services;

public interface ICurrentUserProvider
{
    CurrentUser Get();
}

public record CurrentUser
{
    public Guid Id { get; set; }
}
