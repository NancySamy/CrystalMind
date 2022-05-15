using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrystalMindTask.Repo
{
    public class CrystalMindTaskDbContext : DbContext, ICrystalMindTaskDbContext
    {
        public CrystalMindTaskDbContext(DbContextOptions<CrystalMindTaskDbContext> options)
           : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
