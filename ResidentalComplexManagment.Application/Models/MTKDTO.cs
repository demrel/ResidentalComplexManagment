using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class MTKDTo : BaseDTO
    {
        public string Name { get;  set; }
        public string IBAN { get;  set; }
        public string Address { get;  set; }
        public string PhoneNumber { get;  set; }
    }
}
