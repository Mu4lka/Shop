using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Solution.Host.Domain.Entities;
using Solution.Host.Endpoints.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solution.Host.Infrastructure.Services;

public class JwtGenerator(IConfiguration _configuration) : IJwtGenerator
{
    public string GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey")!);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = CreateClaimsIdentity(),
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = credentials
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);

        ClaimsIdentity CreateClaimsIdentity()
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new(ClaimTypes.NameIdentifier, user.Id.ToString()));

            return claims;
        }
    }
}
