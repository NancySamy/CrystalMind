using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Repo
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CrystalMindTaskDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
