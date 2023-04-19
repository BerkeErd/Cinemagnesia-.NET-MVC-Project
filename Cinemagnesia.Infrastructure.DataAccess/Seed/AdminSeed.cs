using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Cinemagnesia.Domain.Domain.Entities.Concrete;

namespace Infrastructure.DataAccess
{
    public static class AdminSeed
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedAdminAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole("User");
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync("Productor"))
            {
                var role = new IdentityRole("Productor");
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var user = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = DateTime.Now,
                    ProfilePicture = "defaultAdmin.png",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true

                };

                var result = await userManager.CreateAsync(user, "Admin123*");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
