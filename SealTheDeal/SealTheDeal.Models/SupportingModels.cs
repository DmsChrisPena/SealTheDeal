using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealTheDeal.Models
{
    public class Type
    {
        public int IsDeleted { get; set; }
        public bool IsManager { get; set; }
        public bool IsClerk { get; set; }
        public bool IsCustomer { get; set; }
    }

    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
