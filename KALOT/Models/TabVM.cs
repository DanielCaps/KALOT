using KALOT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KALOT.Models
{
    public class TabVM
    {

        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool State { get; set; }
        public decimal Price { get; set; }

        public string User_ID { get; set; }
        public ApplicationUser User { get; set; }
        public List<User> Users { get; set; }

    }
}
