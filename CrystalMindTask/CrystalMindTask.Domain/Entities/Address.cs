using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Domain.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string StreetName { get; set; } = null!;
        public int FlatNo { get; set; }
        public int FloorNo { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
