using AutoMapper;
using KekManager.Data.Models;
using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<LearningProgramModel, LearningProgram>().ReverseMap();
            CreateMap<ResearchFellowModel, ResearchFellow>().ReverseMap();
            CreateMap<ModuleModel, Module>();
        }
    }
}
