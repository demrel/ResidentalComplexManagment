using Ardalis.Specification;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications
{
    internal class AppartmentSelectListSpec : Specification<Appartment, SelectListItemDto>
    {

        public AppartmentSelectListSpec(string buildingId)
        {
            Query.Select(x => new SelectListItemDto
            {
                Id = x.Id,
                Name = x.Name,
            }).Where(c=>c.BuildingId==buildingId);
        }
    
    }
}
