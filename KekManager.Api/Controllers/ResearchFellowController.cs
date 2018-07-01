using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KekManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using KekManager.Domain;
using KekManager.Api.Interfaces;

namespace KekManager.Api.Controllers
{
    [Authorize]
    public class ResearchFellowController : Controller
    {
        protected readonly IResearchFellowBl _researchFellowBl;

        public ResearchFellowController(IResearchFellowBl researchFellowBl)
        {
            _researchFellowBl = researchFellowBl;
        }

        [HttpGet]
        [Route("api/researchFellows")]
        public async Task<ActionResult<IList<LearningProgram>>> All()
        {
            return Ok(await _researchFellowBl.GetAll());
        }
    }
}
