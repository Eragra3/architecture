using Autofac;
using KekManager.Security.Domain;
using KekManager.Security.Logic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.DependancyRegistration
{
    class SecurityModule : Module
    {
        protected readonly IConfiguration _configuration;

        public SecurityModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SecurityBl>()
                .As<ISecurityBl>()
                .WithParameters(
                    new[]
                    {
                        new NamedParameter("jwtIssuer", _configuration["Jwt:Issuer"]),
                        new NamedParameter("jwtAudience", _configuration["Jwt:Audience"]),
                        new NamedParameter("jwtKey", _configuration["Jwt:Key"])
                    }
                );
        }
    }
}
