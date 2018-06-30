using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KekManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using KekManager.Domain;

namespace KekManager.Api.Controllers
{
    [Authorize]
    public class LearningProgramController : Controller
    {
        [HttpGet]
        [Route("api/learningPrograms")]
        public async Task<ActionResult<LearningProgram[]>> All()
        {
            LearningProgram[] learningPrograms = new[] {
                new LearningProgram {
                    Id = 1,
                    Level = Level.Inzynierske,
                    Mode = Mode.Stacjonarne,
                    Name = "Informatyka",
                    NumberOfSemesters = 7,
                    CNPShours = 700
                }
            };

            return learningPrograms;
        }
    }
}
