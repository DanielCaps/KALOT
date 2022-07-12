using KALOT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KALOT.ASL.TabServices
{
    public interface ITabServices
    {
        public IEnumerable<Tab> GetTabs();
        public Task<Tab> CreateTab(Tab tab);
        public Task<bool> DeleteTab(int id);
        public Task<Tab> UpdateTab(Tab tab);
        public Tab GetTabById(int id);

    }
}
