using AutoMapper;
using KekManager.Api.Interfaces;
using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KekManager.Logic
{
    public class LogicMapperProfile : Profile
    {
        public LogicMapperProfile()
        {
            CreateMap<AddLearningProgramParam, LearningProgram>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Modules, opts => opts.Ignore());
        }
    }
}
