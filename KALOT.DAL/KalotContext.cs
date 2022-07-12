using KALOT.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KALOT.DAL
{
    public class KalotContext : IdentityDbContext
    {
        public KalotContext(DbContextOptions<KalotContext> options) : base(options)
        {

        }


        public DbSet<Tab> Tabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        
    }
}
