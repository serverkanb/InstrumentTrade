using InstrumenShop.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using InstrumentTrade.WebUI.SeedData;

namespace InstrumentTrade.WebUI.SeedData
{
  
        public static class IdentityInitializer
        {
            public static async Task SeedRolesAndUsersAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
            {
                // 1. Rolleri oluştur
                string[] roles = { "Admin", "Customer" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new AppRole { Name = role });
                    }
                }

                // 2. Admin kullanıcıyı oluştur
                string adminUsername = "admin";
                string adminEmail = "admin@example.com";
                string adminPassword = "Admin123!";

                if (await userManager.FindByNameAsync(adminUsername) == null)
                {
                    AppUser adminUser = new AppUser
                    {
                        UserName = adminUsername,
                        Email = adminEmail,
                        Name = "Site",
                        Surname = "Yöneticisi",
                        Address = "Admin Merkezi",
                        IsActive = true,
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        // Hataları yazdırmak istersen burayı aç
                        // foreach (var error in result.Errors)
                        // {
                        //     Console.WriteLine(error.Description);
                        // }
                    }
                }
            }
        }
    
}