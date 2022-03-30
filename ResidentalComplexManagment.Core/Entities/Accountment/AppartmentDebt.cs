using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Accountment
{
    public class AppartmentDebt : BaseEntity, IAggregateRoot
    {
        public decimal Value { get;private set; }
        public string  AppartmentId { get; private set; }
        public Appartment Appartment { get; private set; }
        public string PaymentCoefficientId { get; private set; }
        public PaymentCoefficient PaymentCoefficient { get; private set; }

        public AppartmentDebt() { }

        public AppartmentDebt(Appartment appartment)
        {
            Guard.Against.Null(appartment,nameof(appartment));
            Appartment = appartment;
           
        }

        public void GenerateDebt(PaymentCoefficient paymentCoefficient)
        {
            Guard.Against.Null(paymentCoefficient, nameof(paymentCoefficient));
            PaymentCoefficient = paymentCoefficient;
            Value = paymentCoefficient.Value * Appartment.Area;
        }




    }
}
