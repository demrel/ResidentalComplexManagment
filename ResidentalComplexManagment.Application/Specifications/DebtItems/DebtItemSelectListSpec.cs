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
    internal class DebtItemSelectListSpec : Specification<DebtItem, SelectListItemDto>
    {
        public DebtItemSelectListSpec( )
        {
            Query
            .Select(x => new SelectListItemDto
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
