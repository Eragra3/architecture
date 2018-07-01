using KekManager.Database.Interfaces;
using KekManager.Security.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Security.Data.Contexts
{
    public interface ISecurityDbContext : IDatabaseContext
    {
        DbSet<SecurityUser> SecurityUser { get; set; }
    }
}
