using KekManager.Data.Models;
using KekManager.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Contexts
{
    public interface IMainDbContext : IDatabaseContext
    {
        DbSet<LearningProgramModel> LearningProgram { get; set; }

        DbSet<ModuleModel> Module { get; set; }

        DbSet<ResearchFellowModel> ResearchFellow { get; set; }

        DbSet<SubjectModel> Subject { get; set; }

        DbSet<KekModel> Kek { get; set; }

        DbSet<PekModel> Pek { get; set; }
    }
}
