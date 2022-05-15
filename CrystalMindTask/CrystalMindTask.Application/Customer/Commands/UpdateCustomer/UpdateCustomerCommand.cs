using CrystalMindTask.Domain.Entities;
using MediatR;


namespace CrystalMindTask.Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand:IRequest<ResponseCustomer>
    {
        public int CustomerID { get; set; }
        public string CustomerFristName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public char CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
    }
}
