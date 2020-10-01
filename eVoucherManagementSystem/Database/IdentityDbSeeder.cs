using System;
using System.Linq;
using System.Threading.Tasks;
using eVoucherManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace eVoucherManagementSystem.Database
{
    public class IdentityDbSeeder
    {
        public static void Seed(eVoucherMSDBContext dbContext,
                              RoleManager<IdentityRole> roleManager,
                              UserManager<User> userManager)
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }

        }

        private static async Task CreateUsers(
            eVoucherMSDBContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {

           
            if (!await roleManager.RoleExistsAsync(UserRole.Administrator.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Administrator.ToString()));
            }
            if (!await roleManager.RoleExistsAsync(UserRole.RegisteredUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.RegisteredUser.ToString()));
            }

           
            var userAdmin = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Alex",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };
           
            if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await userManager.CreateAsync(userAdmin, "Admin*");
                await userManager.AddToRoleAsync(userAdmin, UserRole.Administrator.ToString());
                await userManager.AddToRoleAsync(userAdmin, UserRole.RegisteredUser.ToString());
               
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
