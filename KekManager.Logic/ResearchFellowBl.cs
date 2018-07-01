using KekManager.Logic.Interfaces;
using System;
using KekManager.Api.Interfaces;
using KekManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace KekManager.Logic
{
    public class ResearchFellowBl : IResearchFellowBl
    {
        protected readonly IResearchFellowRepository _repository;
        protected readonly IMapper _mapper;

        public ResearchFellowBl(IResearchFellowRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IList<ResearchFellow>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
