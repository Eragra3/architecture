using KekManager.Data.Contexts;
using KekManager.Data.Models;
using KekManager.Security.Data.Contexts;
using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Database.Data
{
    public class FullDatabaseContext : IdentityDbContext<SecurityUser>, ISecurityDbContext, IMainDbContext
    {
        public DbSet<SecurityUser> SecurityUser { get; set; }

        public DbSet<LearningProgramModel> LearningProgram { get; set; }

        public DbSet<ModuleModel> Module { get; set; }

        public DbSet<ResearchFellowModel> ResearchFellow { get; set; }

        public FullDatabaseContext(DbContextOptions<FullDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            MainContextModelFluentConfiguration.OnModelCreating(builder);
        }
    }
}
