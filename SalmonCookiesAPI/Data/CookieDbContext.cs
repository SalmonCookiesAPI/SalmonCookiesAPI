using Microsoft.EntityFrameworkCore;
using SalmonCookiesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Data
{
    public class CookieDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        
        public CookieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Location = "Seattle",
                    Description = "",
                    MinimumCustomers = 4,
                    MaximumCustomers = 14,
                    AverageCookiePerSale = 2.5,
                    Owner = null
                });
        }
    }
}
