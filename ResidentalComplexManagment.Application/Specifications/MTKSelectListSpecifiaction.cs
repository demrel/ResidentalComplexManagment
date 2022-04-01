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
    internal class MTKSelectListSpecifiaction : Specification<MKT, SelectListItemDto>
    {
      
            public MTKSelectListSpecifiaction()
            {
                Query.Select(x => new SelectListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                });

            }


        
    }
}
