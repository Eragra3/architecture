using Autofac;
using KekManager.Security.Domain;
using KekManager.Security.Logic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.DependancyRegistration
{
    class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityBl>().As<ISecurityBl>();
        }
    }
}
