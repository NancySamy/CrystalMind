using CrystalMindTask.Application.Customer.Commands.CreateCustomer;
using CrystalMindTask.Dtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application
{
    public interface ICustomerservice
    {
        CustomerResponse CreateCustomer(CreateCustomerCommand req);

    }
}
