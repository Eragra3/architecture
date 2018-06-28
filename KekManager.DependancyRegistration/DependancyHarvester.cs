using Autofac;
using System;

namespace KekManager.DependancyRegistration
{
    public class DependancyHarvester
    {
        public ContainerBuilder Harvest()
        {
            var containerBuilder = new ContainerBuilder();

            return containerBuilder;
        }
    }
}
