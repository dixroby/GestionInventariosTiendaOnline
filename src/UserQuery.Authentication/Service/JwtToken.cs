using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserQuery.Authentication.Option;
using UserQuery.BusinessObjects.Interfaces.Authentication;
using UserQuery.Entities.Dtos;

namespace UserQuery.Authentication.Service;

internal class JwtToken(IOptions<AuthenticationOption> options) : IJwtToken
{
    string IJwtToken.GenerateJwtToken(UserDto user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: options.Value.Issuer,
                                         audience: options.Value.Audience,
                                         claims: claims,
                                         expires: DateTime.Now.AddMinutes(options.Value.Minutes),
                                         signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
