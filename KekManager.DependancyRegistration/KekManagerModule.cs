using Autofac;
using KekManager.Api.Interfaces;
using KekManager.Data.Contexts;
using KekManager.Data.Repositories;
using KekManager.Database;
using KekManager.Database.Data;
using KekManager.Logic;
using KekManager.Logic.Interfaces;
using KekManager.Security.Data.Contexts;

namespace KekManager.DependancyRegistration
{
    class KekManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbInitializer>().As<IDbInitializer>();
            builder.RegisterType<LearningProgramBl>().As<ILearningProgramBl>();
            builder.RegisterType<LearningProgramRepository>().As<ILearningProgramRepository>();
            builder.RegisterType<ResearchFellowBl>().As<IResearchFellowBl>();
            builder.RegisterType<ResearchFellowRepository>().As<IResearchFellowRepository>();
            builder.RegisterType<FullDatabaseContext>().As<IMainDbContext, ISecurityDbContext>();
        }
    }
}