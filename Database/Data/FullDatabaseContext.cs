using KekManager.Security.Data.Contexts;
using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Database.Data
{
    public class FullDatabaseContext : IdentityDbContext<SecurityUser>, ISecurityDbContext
    {
        public DbSet<SecurityUser> SecurityUser { get; set; }

        public FullDatabaseContext(DbContextOptions<FullDatabaseContext> options)
            : base(options)
        {
        }
    }
}
