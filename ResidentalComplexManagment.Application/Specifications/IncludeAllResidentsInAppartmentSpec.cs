using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications
{
    internal class IncludeAllResidentsInAppartmentSpec: Specification<Appartment>, ISingleResultSpecification
    {

        public IncludeAllResidentsInAppartmentSpec(string id )
        {
            Query.Where(c => c.Id == id).Include(c => c.Residents.Where(b => b.IsCurrentResident));
        }



    }
}
