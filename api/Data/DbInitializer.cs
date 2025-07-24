using api.Helpers;
using api.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Manager"))
                await roleManager.CreateAsync(new IdentityRole("Manager"));

            if (await userManager.FindByNameAsync("Administrador") == null)
            {
                var admin = new AppUser
                {
                    UserName = "Administrador",
                    Email = "admin@flores.pt",
                    EmailConfirmed = true,
                    PhoneNumber = "912345678",
                    Role = UserRole.Admin,
                    PIN = PINHasher.HashPIN("123456")
                };

                var result = await userManager.CreateAsync(admin);
                if (!result.Succeeded)
                    throw new Exception("Failed to create admin user.");

                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
