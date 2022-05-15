using CrystalMindTask.Repo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse>
    {
        private IUnitOfWork _unitOfWork;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<GetCustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.Customer.FindAll(c=>c.Addresses).ToListAsync();
            return new GetCustomerResponse() { Customers = customers };

        }

     
    }
}
