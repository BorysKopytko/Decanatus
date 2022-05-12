using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.Classes
{
    public static class SeedRoleAndUser
    {
        public static async Task Initialize(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role1 = new ApplicationRole { };
            role1.Name = "Адміністратор";
            await roleManager.CreateAsync(role1);
            var role2 = new ApplicationRole { };
            role2.Name = "Викладач";
            await roleManager.CreateAsync(role2);
            var role3 = new ApplicationRole { };
            role3.Name = "Студент";
            await roleManager.CreateAsync(role3);

            var user1 = new ApplicationUser
            {
                UserName = "administrator1@lnu.edu.ua",
                Email = "administrator1@lnu.edu.ua",
            };

            await userManager.CreateAsync(user1, "Aa12345678!");
            await userManager.AddToRoleAsync(user1, "Адміністратор");

            var user2 = new ApplicationUser
            {
                UserName = "lecturer1@lnu.edu.ua",
                Email = "lecturer1@lnu.edu.ua",
            };

            await userManager.CreateAsync(user2, "Bb12345678!");
            await userManager.AddToRoleAsync(user2, "Викладач");

            var user3 = new ApplicationUser
            {
                UserName = "student1@lnu.edu.ua",
                Email = "student1@lnu.edu.ua",
            };

            await userManager.CreateAsync(user3, "Cc12345678!");
            await userManager.AddToRoleAsync(user3, "Студент");
        }
    }
}