using ApiUser.Api.Interfaces.Services;
using ApiUser.Api.Model;
using ApiUser.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUser.Api.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GenerateToken(Users user)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(tokenConfig);
            return await Task.FromResult("Bearer "+tokenHandle.WriteToken(token));
        }
    }
}
