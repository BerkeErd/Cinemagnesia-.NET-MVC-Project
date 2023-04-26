using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Seed
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            dbContext.Database.Migrate();
            AdminSeed.InitializeAsync(userManager, roleManager).Wait();
        }
    }
}
