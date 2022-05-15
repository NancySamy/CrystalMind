using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Repo
{
    public interface ICrystalMindTaskDbContext
    {
        DbSet<Domain.Entities.Customer> Customers { get; set; }
        DbSet<Address> Addresses { get; set; }

    }
}
