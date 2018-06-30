using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KekManager.Security.Api.Controllers
{
    [Authorize]
    [Route("api/security/[controller]/[action]")]
    public class HeartbeatController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Hello()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SecretHello()
        {
            return Ok();
        }
    }
}
