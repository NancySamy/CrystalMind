using CrystalMindTask.Repo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResponseCustomer>
    {
        private IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseCustomer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var existedCustomer = _unitOfWork.Customer.FindByCondition(x => x.CustomerID == request.CustomerID).FirstOrDefault();
                if (existedCustomer == null) throw new NotImplementedException();
                var UpdatedCustomer = MapUpdate(existedCustomer, request);
                _unitOfWork.Customer.Update(UpdatedCustomer);
                _unitOfWork.Save();
                return new ResponseCustomer() { CustomerID = UpdatedCustomer.CustomerID };
            }
        }

        private Domain.Entities.Customer MapUpdate(Domain.Entities.Customer existedCustomer, UpdateCustomerCommand request)
        {
            var result = existedCustomer;

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
            return result; ;
        }
    }
}
