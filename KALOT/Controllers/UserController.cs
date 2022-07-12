using KALOT.DAL.Models;
using KALOT.Helpers;
using KALOT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KALOT.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            if(users.Any())
            {
                return View(ORM.ListApplicationUserToListUsers(_userManager.Users.ToList()));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(ORM.UserToApplicationUser(user), "password");

            return RedirectToAction("Index", "User");
        }

    }
}
