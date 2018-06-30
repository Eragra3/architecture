using KekManager.Security.Api.Interfaces;
using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace KekManager.Security.Logic
{
    public interface ISecurityBl
    {
        Task<SignInResult> LoginAsync(string email, string password);

        Task<GenerateTokenResult> GenerateTokenAsync(string email);

        GenerateTokenResult GenerateToken(SecurityUser user);

        JwtSecurityToken ReadToken(string token);
    }
}
