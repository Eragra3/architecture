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
    public class LearningProgramController : Controller
    {
        protected readonly ILearningProgramBl _learningProgramBl;

        public LearningProgramController(ILearningProgramBl learningProgramBl)
        {
            _learningProgramBl = learningProgramBl;
        }

        [HttpGet]
        [Route("api/learningPrograms")]
        public async Task<ActionResult<IList<LearningProgram>>> All()
        {
            return Ok(await _learningProgramBl.GetAll());
        }
    }
}
