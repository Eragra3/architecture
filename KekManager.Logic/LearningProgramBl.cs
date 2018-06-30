using KekManager.Logic.Interfaces;
using System;
using KekManager.Api.Interfaces;
using KekManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KekManager.Logic
{
    public class LearningProgramBl : ILearningProgramBl
    {
        protected readonly ILearningProgramRepository _repository;

        public LearningProgramBl(ILearningProgramRepository repository)
        {
            _repository = repository;
        }

        public Task<IList<LearningProgram>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
