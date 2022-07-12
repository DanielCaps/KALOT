using KALOT.DAL;
using KALOT.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALOT.ASL.TabServices
{
    public class TabServicesRepo : ITabServices
    {
        private readonly KalotContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;

        public TabServicesRepo(KalotContext ctx, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _ctx = ctx;
        }
        public Tab GetTabById(int id)
        {
            return _ctx.Tabs.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Tab> GetTabs()
        {
            return _ctx.Tabs;
        }

        public async Task<Tab> CreateTab(Tab tab)
        {
            try
            {
                tab.User = _userManager.Users.FirstOrDefault(x => x.Id == tab.User_ID);
                _ctx.Add(tab);
                await _ctx.SaveChangesAsync();
                return tab;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Creating tab");
            }
        }

        public async Task<bool> DeleteTab(int id)
        {
            try
            {
                Tab tab = _ctx.Tabs.FirstOrDefault(x => x.ID == id);
                _ctx.Tabs.Remove(tab);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Deleting tab");
            }
        }

        public async Task<Tab> UpdateTab(Tab tab)
        {
            try
            {
                _ctx.Tabs.Update(tab);
                await _ctx.SaveChangesAsync();
                return tab;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Deleting tab");
            }
        }
    }
}
