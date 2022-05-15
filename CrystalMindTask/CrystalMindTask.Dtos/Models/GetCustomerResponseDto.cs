namespace CrystalMindTask.Dtos.Models
{
    public class GetCustomerResponseDto
    {
        public List<CustomerDto> CustomersList { get; set; } = null!;
    }
    public class CustomerDto
    {
        public CustomerDto()
        {
            Addresses = new List<AddressDto>();
        }
        public int CustomerID { get; set; }
        public string CustomerFristName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public char CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public ICollection<AddressDto> Addresses { get; set; }
    }
   
}
