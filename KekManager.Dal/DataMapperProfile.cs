using AutoMapper;
using KekManager.Data.Models;
using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KekManager.Data
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<LearningProgramModel, LearningProgram>().ReverseMap();
            CreateMap<ResearchFellowModel, ResearchFellow>().ReverseMap();
            CreateMap<PekModel, Pek>().ReverseMap();
            CreateMap<ModuleModel, Module>().ReverseMap();

            CreateMap<SubjectModel, Subject>()
                .ForMember(x => x.Keks, opts =>
                {
                    opts.MapFrom(s => s.Keks.Select(j => j.Kek).ToList());
                });
            CreateMap<Subject, SubjectModel>()
                .ForMember(x => x.Keks, opts =>
                {
                    opts.MapFrom(s =>
                        s.Keks
                            .Select(k => new SubjectKekJoinModel
                            {
                                KekId = k.Id,
                                SubjectId = s.Id
                            })
                            .ToList()
                    );
                });

            CreateMap<KekModel, Kek>()
                .ForMember(x => x.Subjects, opts =>
                {
                    opts.MapFrom(k => k.Subjects.Select(j => j.Subject).ToList());
                });
        }
    }
}
