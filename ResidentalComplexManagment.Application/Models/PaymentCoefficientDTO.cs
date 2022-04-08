using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class PaymentCoefficientDTO
    {
        public string Id { get; set; }
        public decimal Value { get;  set; }
        public string Note { get;  set; }
        public DateTime Time { get; set; }
    }
}
