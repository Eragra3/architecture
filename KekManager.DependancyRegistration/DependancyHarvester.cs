using Autofac;
using KekManager.Security.Logic;
using Microsoft.Extensions.Configuration;
using System;

namespace KekManager.DependancyRegistration
{
    public class DependancyHarvester
    {
        public ContainerBuilder Harvest(IConfiguration configuration)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new SecurityModule(configuration));
            containerBuilder.RegisterModule<KekManagerModule>();

            return containerBuilder;
        }
    }
}
