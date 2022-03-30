using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Accountment
{
    public class PaymentCoefficient :BaseEntity
    {
        public decimal Value { get;private set; }

        public PaymentCoefficient() { }

        public PaymentCoefficient(decimal value)
        {
            Value = value;
        }
    }
}
