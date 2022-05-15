using CrystalMindTask.Application.Customer.Commands.CreateCustomer;
using CrystalMindTask.Dtos.Models;
using CrystalMindTask.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Application
{
    public class Customerservice : ICustomerservice
    {
        private IUnitOfWork _unitOfWork;
        public Customerservice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CustomerResponse CreateCustomer(CreateCustomerCommand request)
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
            var result = new Domain.Entities.Customer();

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
