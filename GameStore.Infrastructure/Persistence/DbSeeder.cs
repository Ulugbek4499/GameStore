using GameStore.Domain.Entities.Identity;
using GameStore.Domain.States;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Infrastructure.Persistence
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "AdminFirstName",
                LastName = "AdminLastName",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);

            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }

            var manager = new ApplicationUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                FirstName = "ManagerFirstName",
                LastName = "ManagerLastName",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var managerInDb = await userManager.FindByEmailAsync(manager.Email);

            if (managerInDb == null)
            {
                await userManager.CreateAsync(manager, "Manager@123");
                await userManager.AddToRoleAsync(manager, Roles.Manager.ToString());
            }
        }

    }
}
