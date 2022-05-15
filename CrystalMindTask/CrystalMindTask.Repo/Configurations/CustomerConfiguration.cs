using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Repo.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Define Table Name
            builder.ToTable("Customers");
            // Define PK
            builder.HasKey(c => c.CustomerID);
            // Define Properties Types & Length
            builder.Property(c => c.CustomerFristName).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.CustomerLastName).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.CustomerGender).HasColumnType("char(1)").HasMaxLength(1);
            builder.Property(c => c.CustomerDOB).HasColumnType("Date");
            builder.Property(c => c.CustomerEmail).HasColumnType("nvarchar(50)").HasMaxLength(50);

            //Define One to Many Relation Ship
            builder.HasMany(c => c.Addresses).WithOne(a => a.Customer).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
