using Autofac;
using KekManager.Database;

namespace KekManager.DependancyRegistration
{
    class KekManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbInitializer>().As<IDbInitializer>();
        }
    }
}