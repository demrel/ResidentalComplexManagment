using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Accountment
{
    public class PaymentCoefficient :BaseEntity, IAggregateRoot
    {
        public decimal Value { get;private set; }
        public string Note { get; private set; }
        public PaymentCoefficient() { }

        public PaymentCoefficient(decimal value,string note)
        {
            Value = value;
            Note= note;
        }
    }
}
