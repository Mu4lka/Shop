using Solution.Host.Domain.Entities;

namespace Solution.Host.Endpoints.Services;

internal interface IJwtGenerator
{
    string GenerateToken(User user);
}