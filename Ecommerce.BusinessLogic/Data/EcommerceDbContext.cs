using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(
            DbContextOptions<EcommerceDbContext>options)
            : base(options) { }
       

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



    }


}
