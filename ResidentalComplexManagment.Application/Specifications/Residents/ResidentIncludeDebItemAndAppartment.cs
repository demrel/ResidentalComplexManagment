using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications.Residents
{
    internal class ResidentIncludeDebItemAndAppartment: Specification<Resident>, ISingleResultSpecification
    {
        public ResidentIncludeDebItemAndAppartment(string id)
        {
            Query.Include(c => c.ResidentDebtItems)
                 .Include(c=>c.Appartment)
                 .Include(c=>c.ResidentDiscounts)
                 .Where(c=>c.Id==id);
        }
    }
}
