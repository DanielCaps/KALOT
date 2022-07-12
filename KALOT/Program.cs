using KALOT.DAL;
using KALOT.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KALOT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<KalotContext>();
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                ctx.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                var managerRole = new IdentityRole("Manager");
                var userRole = new IdentityRole("User");
                if (!ctx.Roles.Any(r => r.Name == "Manager"))
                {
                    roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                    roleMgr.CreateAsync(managerRole).GetAwaiter().GetResult();
                    roleMgr.CreateAsync(userRole).GetAwaiter().GetResult();
                }
                if (!ctx.Users.Any(u => u.UserName == "relde"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@test.com",
                    };
                    var capsUser = new ApplicationUser
                    {
                        UserName = "caps",
                        Email = "caps@test.com",
                    };
                    var andreUser = new ApplicationUser
                    {
                        UserName = "andre",
                        Email = "andre@test.com",
                    };
                    var reldeUser = new ApplicationUser
                    {
                        UserName = "relde",
                        Email = "relde@test.com",
                    };
                    userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    userMgr.CreateAsync(capsUser, "password").GetAwaiter().GetResult();
                    userMgr.CreateAsync(andreUser, "password").GetAwaiter().GetResult();
                    userMgr.CreateAsync(reldeUser, "password").GetAwaiter().GetResult();

                    userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                    userMgr.AddToRoleAsync(capsUser, adminRole.Name).GetAwaiter().GetResult();
                    userMgr.AddToRoleAsync(andreUser, adminRole.Name).GetAwaiter().GetResult();
                    userMgr.AddToRoleAsync(reldeUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
