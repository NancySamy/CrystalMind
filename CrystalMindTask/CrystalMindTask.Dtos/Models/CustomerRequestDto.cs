namespace CrystalMindTask.Dtos.Models
{
    public class CustomerRequestDto
    {
        public string CustomerFristName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public char CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public ICollection<AddressDto> Addresses { get; set; }
    }
    public class AddressDto
    {
        public string StreetName { get; set; } = null!;
        public int FlatNo { get; set; }
        public int FloorNo { get; set; }
    }

}
