using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundless.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public uint Zip { get; set; }
        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Fax1 { get; set; }

        public string Fax2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
