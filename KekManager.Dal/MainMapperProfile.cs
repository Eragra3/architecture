using AutoMapper;
using KekManager.Data.Models;
using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data
{
    public class MainMapperProfile : Profile
    {
        public MainMapperProfile()
        {
            CreateMap<LearningProgramModel, LearningProgram>();
            CreateMap<ModuleModel, Module>();
        }
    }
}
