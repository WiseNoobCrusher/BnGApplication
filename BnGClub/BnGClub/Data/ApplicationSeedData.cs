using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Data
{
    public static class ApplicationSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Parent", "Instructor", "Admin" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("admin@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@outlook.com",
                    Email = "admin@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("eremington@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "eremington@gmail.com",
                    Email = "eremington@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Parent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("ciaraace12@hotmail.ca").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "ciaraace12@hotmail.ca",
                    Email = "ciaraace12@hotmail.ca"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Parent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("mvpbruce69@yahoo.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "mvpbruce69@yahoo.com",
                    Email = "mvpbruce69@yahoo.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Parent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("mcody@hotmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "mcody@hotmail.com",
                    Email = "mcody@hotmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Parent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("jjfinley@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "jjfinley@outlook.com",
                    Email = "jjfinley@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Parent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("harrypotter@yahoo.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "harrypotter@yahoo.com",
                    Email = "harrypotter@yahoo.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
            if (userManager.FindByEmailAsync("ashleymcdaniel@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "ashleymcdaniel@outlook.com",
                    Email = "ashleymcdaniel@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
            if (userManager.FindByEmailAsync("zacmarion64@hotmail.ca").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "zacmarion64@hotmail.ca",
                    Email = "zacmarion64@hotmail.ca"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
            if (userManager.FindByEmailAsync("carlosmweeney@hotmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "carlosmweeney@hotmail.com",
                    Email = "carlosmweeney@hotmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
            if (userManager.FindByEmailAsync("lmathis@yahoo.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "lmathis@yahoo.com",
                    Email = "lmathis@yahoo.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
            if (userManager.FindByEmailAsync("user1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user@outlook.com",
                    Email = "user@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
            }
        }
    }
}
