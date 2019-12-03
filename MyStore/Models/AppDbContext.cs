using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class AppDbContext:DbContext
    {
        //Product Category (New Product, Used Product, New Parts, Used Parts)
        public DbSet<Category> PCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Compatibility> PCompatibilities { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PType> PTypes { get; set; }

        public AppDbContext()
            : base("name=DefaultConnection")
        {

        }
    }
}