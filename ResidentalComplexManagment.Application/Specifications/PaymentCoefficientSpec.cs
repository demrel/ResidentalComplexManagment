using Ardalis.Specification;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.Accountment;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications
{
    internal  class PaymentCoefficientSpec : Specification<PaymentCoefficient,PaymentCoefficientDTO>
    {
        public PaymentCoefficientSpec()
        {
            Query.Select(x => new PaymentCoefficientDTO
            {
                Id = x.Id,
                Time=x.Created,
                Note=x.Note,
                Value = x.Value,
           }).OrderByDescending(c=>c.Created);
        }
    }
}
