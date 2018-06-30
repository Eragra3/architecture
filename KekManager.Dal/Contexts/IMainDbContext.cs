using KekManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Contexts
{
    public interface IMainDbContext
    {
        DbSet<LearningProgramModel> LearningProgram { get; set; }

        DbSet<ModuleModel> Module { get; set; }
    }
}
