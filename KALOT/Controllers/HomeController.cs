using KALOT.ASL.TabServices;
using KALOT.DAL.Models;
using KALOT.Helpers;
using KALOT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KALOT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITabServices _tabServices;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            ITabServices tabServices, 
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _tabServices = tabServices;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var res = new List<TabVM>();
            var tabs = ORM.ListTabToTabVM(_tabServices.GetTabs().ToList());
            var users = _userManager.Users.ToList();
            foreach (var t in tabs)
            {
                t.User = users.Where(x => x.Id == t.User_ID).FirstOrDefault();
                res.Add(t);
            }
            return View(res);

        }
        [HttpGet]
        public IActionResult CreateTab()
        {
            return View(
                new TabVM 
                {
                    CreatedDate = DateTime.Today,
                    Users = ORM.ListApplicationUserToListUsers(_userManager.Users.ToList()),
                });
        }
        [HttpPost]
        public async Task<IActionResult> CreateTab(Tab tab)
        {
            var criaTabRes = await _tabServices.CreateTab(tab);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditTab(int id)
        {
            var res = _tabServices.GetTabById(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> EditTab(Tab tab)
        {
            var editaTabRes = await _tabServices.UpdateTab(tab);
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> DeleteTab(int id)
        {
            var deleteTab = await _tabServices.DeleteTab(id);
            return RedirectToAction("Index", "Home");
        }



        // Products Service
        // Cat Service
        // Est Service
        
        // Check Automapper
        // Teste GitHub




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
