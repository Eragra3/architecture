using Autofac;
using KekManager.Security.Logic;
using System;

namespace KekManager.DependancyRegistration
{
    public class DependancyHarvester
    {
        public ContainerBuilder Harvest()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<SecurityModule>();
            containerBuilder.RegisterModule<KekManagerModule>();

            return containerBuilder;
        }
    }
}
