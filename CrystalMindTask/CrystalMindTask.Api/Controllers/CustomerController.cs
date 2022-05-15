using CrystalMindTask.Application;
using CrystalMindTask.Application.Customer.Commands.CreateCustomer;
using CrystalMindTask.Application.Customer.Commands.DeleteCustomer;
using CrystalMindTask.Application.Customer.Commands.UpdateCustomer;
using CrystalMindTask.Application.Customer.Queries.GetCustomer;
using CrystalMindTask.Domain.Entities;
using CrystalMindTask.Dtos.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrystalMindTask.Api.Controllers
{

    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private ICustomerservice _customerservice;
        private IMediator _mediator;
        //protected IMediator _mediator => mediator = HttpContext.RequestServices.GetService<IMediator>();
        public CustomerController(ICustomerservice customerservice, IMediator mediator)
        {
            _customerservice = customerservice;
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCustomer")]
        [Route("AddCustomer")]
        public  CustomerResponseDto AddCustomer(CustomerRequestDto customer)
        {
            var command = new CreateCustomerCommand
            {
                CustomerFristName = customer.CustomerFristName,
                CustomerLastName = customer.CustomerLastName,
                CustomerGender = customer.CustomerGender,
                CustomerDOB = customer.CustomerDOB,
                CustomerEmail = customer.CustomerEmail,
                Addresses = customer.Addresses.Select(customerAddress => new Domain.Entities.Address
                {
                    StreetName = customerAddress.StreetName,
                    FlatNo = customerAddress.FlatNo,
                    FloorNo = customerAddress.FloorNo
                }).ToList()
            };

            var response =  _customerservice.CreateCustomer(command);

            return new CustomerResponseDto
            {
                CustomerId = response.CustomerID
            };
        }

        [HttpPut(Name = "UpdateCustomer")]
        [Route("UpdateCustomer/{id}")]
        public async Task<CustomerResponseDto> UpdateCustomer([FromRoute] int id, [FromBody] CustomerRequestDto customer)
        {
            var command = new UpdateCustomerCommand
            {
                CustomerID = id,
                CustomerFristName = customer.CustomerFristName,
                CustomerLastName = customer.CustomerLastName,
                CustomerGender = customer.CustomerGender,
                CustomerDOB = customer.CustomerDOB,
                CustomerEmail = customer.CustomerEmail,
                Addresses = customer.Addresses.Select(customerAddress => new Domain.Entities.Address
                {
                    StreetName = customerAddress.StreetName,
                    FlatNo = customerAddress.FlatNo,
                    FloorNo = customerAddress.FloorNo
                }).ToList()
            };

            var response = await _mediator.Send(command);

            return new CustomerResponseDto
            {
                CustomerId = response.CustomerID
            };
        }

        //[HttpDelete(Name = "DeleteCustomer")]
        //[Route("DeleteCustomer/{id}")]
        //public async Task<CustomerResponseDto> DeleteCustomer([FromRoute] int id)
        //{
        //    var command = new DeleteCustomerCommand
        //    {
        //        CustomerID = id
        //    };

        //    var response = await _mediator.Send(command);

        //    return new CustomerResponseDto
        //    {
        //        CustomerId = response.CustomerID
        //    };
        //}

        [HttpGet(Name = "GetCustomer")]
        [Route("GetCustomer")]
        public async Task<GetCustomerResponseDto> GetCustomer()
        {
            var query = new GetCustomerQuery();

            var response = await _mediator.Send(query);

            return new GetCustomerResponseDto()
            {
                CustomersList = Map(response.Customers)
            };
        }

        private List<CustomerDto> Map(List<Customer> customers)
        {
            var result = new List<CustomerDto>();
            foreach (var custom in customers)
            {
                result.Add(new CustomerDto()
                {
                    Addresses =
                    custom.Addresses.Select(customerAddress => new AddressDto()
                    {
                        StreetName = customerAddress.StreetName,
                        FlatNo = customerAddress.FlatNo,
                        FloorNo = customerAddress.FloorNo
                    }).ToList(),
                    CustomerDOB = custom.CustomerDOB,
                    CustomerEmail = custom.CustomerEmail,
                    CustomerFristName = custom.CustomerFristName,
                    CustomerGender = custom.CustomerGender,
                    CustomerID = custom.CustomerID,
                    CustomerLastName = custom.CustomerLastName
                });
            }
            return result;
        }
    }
}

