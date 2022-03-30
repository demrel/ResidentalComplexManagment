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
    public  class AppartmentSpecifiaction : Specification<Appartment, AppartmentDTO>
    {
        public AppartmentSpecifiaction()
        {
            Query.Select(x => new AppartmentDTO
            {
               Id= x.Id,
               DoorNumber= x.DoorNumber,
               Created = x.Created,
            });
              
        }


    }
}
