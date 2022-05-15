using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new List<Address>();
        }
        public int CustomerID { get; set; }
        public string CustomerFristName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public char CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerEmail { get; set; }=null!;
        public ICollection<Address> Addresses { get; set; }
    }
}
