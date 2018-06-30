using KekManager.Database.Data;
using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekManager.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly FullDatabaseContext _context;
        private readonly UserManager<SecurityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            FullDatabaseContext context,
            UserManager<SecurityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async Task Initialize()
        {
            //create database schema if none exists
            _context.Database.Migrate();

            if (!await _roleManager.RoleExistsAsync("Administrator"))
            {
                //Create the Administartor Role
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                //Create the User Role
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            {
                var admin = new SecurityUser
                {
                    UserName = "admin",
                    Email = "admin@kekmanager.com",
                    EmailConfirmed = true
                };
                if (await _userManager.FindByNameAsync(admin.UserName) == null)
                {
                    //Create the default Admin account and apply the Administrator role
                    await _userManager.CreateAsync(admin, "1qaz@WSX");
                    var adminRoles = new[] { "User", "Administrator" };
                    await _userManager.AddToRolesAsync(await _userManager.FindByNameAsync(admin.UserName), adminRoles);
                }
            }

            {
                //Create the default User account and apply the User role
                var user = new SecurityUser
                {
                    UserName = "user",
                    Email = "user@kekmanager.com",
                    EmailConfirmed = true
                };
                if (await _userManager.FindByNameAsync(user.UserName) == null)
                {
                    await _userManager.CreateAsync(user, "1qaz@WSX");
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), "User");
                }
            }
        }
    }
}
