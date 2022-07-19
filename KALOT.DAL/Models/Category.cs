using System;
using System.Collections.Generic;
using System.Text;

namespace KALOT.DAL.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
