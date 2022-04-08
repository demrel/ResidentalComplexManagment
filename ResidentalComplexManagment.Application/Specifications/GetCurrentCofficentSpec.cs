using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications
{
    internal class GetCurrentCofficentSpec : Specification<PaymentCoefficient, decimal>
    {
        public GetCurrentCofficentSpec()
        {
           var a= Query.Select(c=>c.Value).OrderByDescending(c => c.Created).Take(1);
        }
    }
}
