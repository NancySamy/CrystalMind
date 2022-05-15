using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand:IRequest<ResponseCustomer>
    {
        public int CustomerID { get; set; }
    }
}
