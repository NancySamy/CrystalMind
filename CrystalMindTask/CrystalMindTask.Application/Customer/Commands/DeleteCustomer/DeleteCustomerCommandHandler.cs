using CrystalMindTask.Repo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseCustomer>
    {
        private IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseCustomer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
              _unitOfWork.Customer.DeleteBy(c=>c.CustomerID== request.CustomerID,c=>c.Addresses);
                _unitOfWork.Save();

                return new ResponseCustomer() { CustomerID = request.CustomerID };
            }
        }
    }
}
