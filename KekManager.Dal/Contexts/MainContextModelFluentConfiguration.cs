using KekManager.Data.Models;
using KekManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Contexts
{
    public static class MainContextModelFluentConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<LearningProgramModel>(entity =>
                {
                    entity.HasData(
                        new LearningProgramModel
                        {
                            Id = 1,
                            Name = "Informatyka",
                            CnpsHours = 700,
                            Level = Level.Inzynierske,
                            Mode = Mode.Niestacjonarne,
                            NumberOfSemesters = 8,
                            Specialization = ""
                        },
                        new LearningProgramModel
                        {
                            Id = 2,
                            Name = "Informatyka",
                            CnpsHours = 700,
                            Level = Level.Inzynierske,
                            Mode = Mode.Stacjonarne,
                            NumberOfSemesters = 7,
                            Specialization = ""
                        },
                        new LearningProgramModel
                        {
                            Id = 3,
                            Name = "Informatyka",
                            CnpsHours = 700,
                            Level = Level.Magisterskie,
                            Mode = Mode.Niestacjonarne,
                            NumberOfSemesters = 4,
                            Specialization = "Projektowanie Systemów Informatycznych"
                        },
                        new LearningProgramModel
                        {
                            Id = 4,
                            Name = "Informatyka",
                            CnpsHours = 1200,
                            Level = Level.Magisterskie,
                            Mode = Mode.Stacjonarne,
                            NumberOfSemesters = 3,
                            Specialization = "Danologia"
                        }
                    );
                });

            builder
                .Entity<ModuleModel>(entity =>
                {
                    entity.HasData(new[]
                    {
                        new ModuleModel { Id = 1, Name = "Aplikacje Webowe", Area = CourseArea.Kierunkowe, LearningProgramId = 1 },
                        new ModuleModel { Id = 2, Name = "Przedmioty Humanistyczne", Area = CourseArea.NaukiHumanistyczne, LearningProgramId = 1 },
                        new ModuleModel { Id = 3, Name = "Zajęcia Sportowe", Area = CourseArea.ZajeciaSportowe, LearningProgramId = 1 },
                        new ModuleModel { Id = 4, Name = "Aplikacje Webowe", Area = CourseArea.Kierunkowe, LearningProgramId = 2 },
                        new ModuleModel { Id = 5, Name = "Przedmioty Humanistyczne", Area = CourseArea.NaukiHumanistyczne, LearningProgramId = 2 },
                        new ModuleModel { Id = 6, Name = "Zajęcia Sportowe", Area = CourseArea.ZajeciaSportowe, LearningProgramId = 2 },
                        new ModuleModel { Id = 7, Name = "Aplikacje Webowe", Area = CourseArea.Kierunkowe, LearningProgramId = 3 },
                        new ModuleModel { Id = 8, Name = "Przedmioty Humanistyczne", Area = CourseArea.NaukiHumanistyczne, LearningProgramId = 3 },
                        new ModuleModel { Id = 9, Name = "Aplikacje Webowe", Area = CourseArea.Kierunkowe, LearningProgramId = 4 },
                        new ModuleModel { Id = 10, Name = "Przedmioty Humanistyczne", Area = CourseArea.NaukiHumanistyczne, LearningProgramId = 4 },
                    });
                });

            builder
                .Entity<ResearchFellowModel>(entity =>
                {
                    entity.HasData(new []
                    {
                        new ResearchFellowModel { Id = 1, UserId = 3, FirstName = "Daniel", LastName = "Bider", Title = "inż." },
                        new ResearchFellowModel { Id = 2, UserId = null, FirstName = "Szymon", LastName = "Barańczyk", Title = "inż." },
                        new ResearchFellowModel { Id = 3, UserId = null, FirstName = "John", LastName = "Doe", Title = "mgr inż." }
                    });
                });
        }
    }
}
