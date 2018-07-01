using KekManager.Logic.Interfaces;
using System;
using KekManager.Api.Interfaces;
using KekManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace KekManager.Logic
{
    public class LearningProgramBl : ILearningProgramBl
    {
        protected readonly ILearningProgramRepository _repository;
        protected readonly IMapper _mapper;

        public LearningProgramBl(ILearningProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<LearningProgram> Add(AddLearningProgramParam param)
        {
            var repoParam = _mapper.Map<LearningProgram>(param);
            return _repository.Add(repoParam);
        }

        public Task<IList<LearningProgram>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
