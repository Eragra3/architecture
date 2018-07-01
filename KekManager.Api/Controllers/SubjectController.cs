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
    public class SubjectController : Controller
    {
        protected readonly ISubjectBl _subjectBl;

        public SubjectController(ISubjectBl subjectBl)
        {
            _subjectBl = subjectBl;
        }

        [HttpGet]
        [Route("api/subjects")]
        public async Task<ActionResult<IList<LearningProgram>>> All()
        {
            return Ok(await _subjectBl.GetAll());
        }

        [HttpPatch]
        [Route("api/subject/{id}/supervisor/{supervisorId}")]
        public async Task<ActionResult<IList<LearningProgram>>> Update(int id, int? supervisorId)
        {
            return Ok(await _subjectBl.SetSupervisor(id, supervisorId));
        }
    }
}
