//using Microsoft.AspNetCore.Identity;
//using Portfolio.Core.ProfileUser;

//public static class IdentitySeeder
//{
//    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<Role> roleManager)
//    {
//        var roles = new[] { "Admin", "Recruiter", "Developer" };

//        foreach (var role in roles)
//        {
//            if (!await roleManager.RoleExistsAsync(role))
//            {
//                await roleManager.CreateAsync(new Role
//                {
//                    Name = role,
//                    NormalizedName = role.ToUpper()
//                });
//            }
//        }

//        var adminEmail = "admin@portfolio.com";
//        var adminUser = await userManager.FindByEmailAsync(adminEmail);

//        if (adminUser == null)
//        {
//            var admin = new AppUser
//            {
//                Id = Guid.NewGuid(),
//                UserName = adminEmail,
//                Email = adminEmail,
//                FirstName = "System",
//                LastName = "Admin",
//                EmailConfirmed = true
//            };

//            var result = await userManager.CreateAsync(admin, "Admin@123");

//            if (result.Succeeded)
//            {
//                await userManager.AddToRoleAsync(admin, "Admin");
//            }
//            else
//            {
//                throw new Exception("Failed to seed admin: " + string.Join(", ", result.Errors.Select(e => e.Description)));
//            }
//        }
//    }
//}
