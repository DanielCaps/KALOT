using KALOT.DAL.Models;
using KALOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KALOT.Helpers
{
    public class ORM
    {
        public static ApplicationUser UserToApplicationUser(User u)
        {
            return new ApplicationUser
            {
                Id = u.Id,
                UserName = u.UserName,
                NormalizedUserName = u.NormalizedUserName,
                Email = u.Email,
                NormalizedEmail = u.NormalizedEmail,
                EmailConfirmed = u.EmailConfirmed,
                PasswordHash = u.PasswordHash,
                SecurityStamp = u.SecurityStamp,
                ConcurrencyStamp = u.ConcurrencyStamp,
                PhoneNumber = u.PhoneNumber,
                PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                TwoFactorEnabled = u.TwoFactorEnabled,
                LockoutEnd = u.LockoutEnd,
                LockoutEnabled = u.LockoutEnabled,
                AccessFailedCount = u.AccessFailedCount,
            };
        }
        public static User ApplicationUserToUser(ApplicationUser u)
        {
            return new User
            {
                Id = u.Id,
                UserName = u.UserName,
                NormalizedUserName = u.NormalizedUserName,
                Email = u.Email,
                NormalizedEmail = u.NormalizedEmail,
                EmailConfirmed = u.EmailConfirmed,
                PasswordHash = u.PasswordHash,
                SecurityStamp = u.SecurityStamp,
                ConcurrencyStamp = u.ConcurrencyStamp,
                PhoneNumber = u.PhoneNumber,
                PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                TwoFactorEnabled = u.TwoFactorEnabled,
                LockoutEnd = u.LockoutEnd ?? new DateTimeOffset(),
                LockoutEnabled = u.LockoutEnabled,
                AccessFailedCount = u.AccessFailedCount,
            };
        }
        public static List<User> ListApplicationUserToListUsers(List<ApplicationUser> users)
        {
            var res = new List<User>();
            foreach(var u in users)
            {
                res.Add(ApplicationUserToUser(u));
            }
            return res;
        }
        public static List<ApplicationUser> ListUsersToListApplicationUser(List<User> users)
        {
            var res = new List<ApplicationUser>();
            foreach (var u in users)
            {
                res.Add(UserToApplicationUser(u));
            }
            return res;
        }

        public static TabVM TabToTabVM(Tab tab)
        {
            return new TabVM
            {
                ID = tab.ID,
                CreatedDate = tab.CreatedDate,
                Price = tab.Price,
                State = tab.State,
                User = tab.User,
                User_ID = tab.User_ID,
            };
        }
        public static Tab TabVMToTab(TabVM tab)
        {
            return new Tab
            {
                ID = tab.ID,
                CreatedDate = tab.CreatedDate,
                Price = tab.Price,
                State = tab.State,
                User = tab.User,
                User_ID = tab.User_ID,
            };
        }
        public static List<Tab> ListTabVMToTab(List<TabVM> tabs)
        {
            var res = new List<Tab>();
            foreach (var u in tabs)
            {
                res.Add(TabVMToTab(u));
            }
            return res;
        }
        public static List<TabVM> ListTabToTabVM(List<Tab> tabs)
        {
            var res = new List<TabVM>();
            foreach (var u in tabs)
            {
                res.Add(TabToTabVM(u));
            }
            return res;
        }
    }
}
