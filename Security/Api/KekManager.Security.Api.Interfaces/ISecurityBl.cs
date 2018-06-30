using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KekManager.Security.Logic
{
    public interface ISecurityBl
    {
        Task<SignInResult> LoginAsync(string email, string password);

        Task<string> GenerateTokenAsync(string email);

        string GenerateToken(SecurityUser user);
    }
}
