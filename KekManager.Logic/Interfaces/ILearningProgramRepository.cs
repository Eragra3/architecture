using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekManager.Logic.Interfaces
{
    public interface ILearningProgramRepository
    {
        Task<IList<LearningProgram>> GetAll();

        Task<LearningProgram> Add(LearningProgram param);
    }
}
