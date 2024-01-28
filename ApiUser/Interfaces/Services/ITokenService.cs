using ApiUser.Domain.Entities;

namespace ApiUser.Api.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Users user);
    }
}
