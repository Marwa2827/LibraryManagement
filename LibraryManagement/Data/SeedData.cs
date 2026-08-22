using LibraryManagement.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            var userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles =
            {
                "Administrator",
                "Librarian",
                "Staff"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole<int>(role));
                }
            }

            var adminEmail = "admin@library.com";

            var adminUser =
                await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "System Administrator",
                    EmailConfirmed = true,
                    IsActive = true
                };

                var result = await userManager.CreateAsync(
                    adminUser,
                    "Admin@123");

                if (!result.Succeeded)
                {
                    var errors = string.Join(
                        ", ",
                        result.Errors.Select(e => e.Description));

                    throw new Exception(
                        $"Failed to create admin user: {errors}");
                }

                await userManager.AddToRoleAsync(
                    adminUser,
                    "Administrator");
            }
        }
    }
}
