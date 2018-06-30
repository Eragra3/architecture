using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KekManager.Security.Logic
{
    public class SecurityBl : ISecurityBl
    {
        protected readonly UserManager<SecurityUser> _userManager;
        protected readonly SignInManager<SecurityUser> _signInManager;
        protected readonly string _jwtIssuer;
        protected readonly string _jwtKey;
        protected readonly string _jwtAudience;

        public SecurityBl(
            UserManager<SecurityUser> userManager,
            SignInManager<SecurityUser> signInManager,
            string jwtIssuer,
            string jwtKey,
            string jwtAudience)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtIssuer = jwtIssuer;
            _jwtKey = jwtKey;
            _jwtAudience = jwtAudience;
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            //This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var user = await _userManager.FindByEmailAsync(email);
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

        public async Task<string> GenerateTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;
            await _signInManager.SignOutAsync();
            return GenerateToken(user);
        }

        public string GenerateToken(SecurityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_jwtIssuer,
              _jwtAudience,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
