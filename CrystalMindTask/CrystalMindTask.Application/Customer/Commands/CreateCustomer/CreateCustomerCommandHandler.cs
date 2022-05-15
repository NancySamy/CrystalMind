using CrystalMindTask.Repo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var Response = new CustomerResponse();
                var customerEntity = Map(request);
                _unitOfWork.Customer.Create(customerEntity!);
                Response.CustomerID = customerEntity.CustomerID;
                _unitOfWork.Save();
                return Response;
            }
        }

        private Domain.Entities.Customer Map(CreateCustomerCommand request)
        {
            var result=new Domain.Entities.Customer();

                result.CustomerFristName = request.CustomerFristName;
                result.CustomerLastName = request.CustomerLastName;
                result.CustomerGender = request.CustomerGender;
                result.CustomerDOB = request.CustomerDOB;
                result.CustomerEmail = request.CustomerEmail;
                result.Addresses = request.Addresses.Select(customerAddress => new Domain.Entities.Address
                {
                    StreetName = customerAddress.StreetName,
                    FlatNo = customerAddress.FlatNo,
                    FloorNo = customerAddress.FloorNo
                }).ToList();
            return result;
        }
    }
}
