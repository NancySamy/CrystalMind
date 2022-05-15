using System;
using CrystalMindTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrystalMindTask.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private CrystalMindTaskDbContext context ;
        public UnitOfWork(CrystalMindTaskDbContext dbContext)
        {
            this.context = dbContext;
            this.Customer = new CustomerRepository(dbContext);
            this.Address=new AddressRepository(dbContext);
        }


        public IAddressRepository Address { get; private set; }

        public ICustomerRepository Customer { get; private set; }
        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}