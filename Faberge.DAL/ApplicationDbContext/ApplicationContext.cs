using Faberge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.DAL.ApplicationDbContext
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("FabergeStore") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
