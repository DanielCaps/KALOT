using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KALOT.DAL.Models
{
    public class Tab
    {
        [Key]
        public int ID { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public bool State { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("User")]
        public string User_ID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
