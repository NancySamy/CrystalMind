using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTest.infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Define Table Name
            builder.ToTable("Addresses");
            //Define PK
            builder.HasKey(a=>a.AddressID);
            //Define Properties DataType & MaxLength
            builder.Property(a=>a.StreetName).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(a=>a.FloorNo).HasColumnType("Number");
            builder.Property(a=>a.FlatNo).HasColumnType("Number");
            //Define RelationShip
            builder.HasOne(a => a.Customer).WithMany(c => c.Addresses);
        }
    }
}
