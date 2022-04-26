using Ardalis.Specification;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications.DebtItems
{
    internal class DebtItemIncludeCalcSpec : Specification<DebtItem>,ISingleResultSpecification
    {
        public DebtItemIncludeCalcSpec( )
        {
            Query.Include(c => c.CalculationValues);
            
        }

        public DebtItemIncludeCalcSpec(string id)
        {
            Query.Include(c => c.CalculationValues).Where(c=>c.Id==id);

        }
    }
}
