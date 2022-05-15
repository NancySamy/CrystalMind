using CrystalMindTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<CustomerResponse>
    {
        public string CustomerFristName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public char CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
    }
}
