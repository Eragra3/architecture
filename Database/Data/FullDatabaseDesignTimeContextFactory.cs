using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Database.Data
{
    public class FullDatabaseDesignTimeContextFactory : IDesignTimeDbContextFactory<FullDatabaseContext>
    {
        private readonly IConfigurationRoot _configuration;

        public FullDatabaseDesignTimeContextFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
#if DEBUG
                .AddJsonFile("appsettings.debug.json", optional: false, reloadOnChange: true);
#else
                .AddJsonFile("appsettings.release.json", optional: false, reloadOnChange: true);
#endif

            _configuration = builder.Build();
        }

        public FullDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FullDatabaseContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("KekManager"), m =>
            {
                m.EnableRetryOnFailure();
            });

            return new FullDatabaseContext(optionsBuilder.Options);
        }
    }
}
