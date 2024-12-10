using Solution.Host.Endpoints.Services;
using System.Security.Claims;

namespace Solution.Host.Infrastructure.Services;

internal class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser Get()
    {
        var claims = _httpContextAccessor.HttpContext!.User.Claims;

        var nameIdentifier = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

        Guid id = Guid.Parse(nameIdentifier);
        return new CurrentUser { Id = id };
    }
}
