using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KekManager.Security.Api.Models.AccountViewModels;
using KekManager.Security.Api.Services;
using KekManager.Security.Domain;
using KekManager.Security.Logic;
using System.Net;
using KekManager.Security.Api.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;

namespace KekManager.Security.Api.Controllers
{
    [Authorize]
    [Route("api/security/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ISecurityBl _securityBl;

        public AccountController(ISecurityBl securityBl)
        {
            _securityBl = securityBl;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _securityBl.LoginAsync(model.Email, model.Password);

            if (result.Succeeded)
            {
                // Generate new Token
                var tokenResult = await _securityBl.GenerateTokenAsync(model.Email);

                if (tokenResult == null)
                {
                    return StatusCode(500);
                }

                return Ok(tokenResult);
            }
            else if (result.IsLockedOut)
            {
                return UnprocessableEntity();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromHeader, BindRequired]string authorization)
        {
            var token = _securityBl.ReadToken(authorization.Split(' ')[1]);
            var email = token.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value;
            var tokenResult = await _securityBl.GenerateTokenAsync(email);

            if (tokenResult == null)
            {
                return StatusCode(500);
            }

            return Ok(tokenResult);
        }
    }
}
