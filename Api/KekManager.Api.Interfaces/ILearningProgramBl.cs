using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KekManager.Api.Interfaces
{
    public interface ILearningProgramBl
    {
        Task<IList<LearningProgram>> GetAll();
    }
}
