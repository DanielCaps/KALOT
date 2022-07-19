using System;
using System.Collections.Generic;
using System.Text;

namespace KALOT.DAL.Models
{
    public class Establishment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CretedDate { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }


        public ICollection<Tab> Tabs { get; set; }

    }
}
