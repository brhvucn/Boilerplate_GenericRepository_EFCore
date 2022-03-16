using Centisoft.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.DataAccess.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() { } //for EF
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure EF to delete all contacts when a customer is deleted
            modelBuilder.Entity<Customer>()
                .HasMany(x=>x.Contacts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
