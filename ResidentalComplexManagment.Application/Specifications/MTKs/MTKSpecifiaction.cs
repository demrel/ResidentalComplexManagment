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
    internal  class MTKSpecifiaction : Specification<MKT,MTKDTO>
    {
        public MTKSpecifiaction()
        {
            Query.Select(x => new MTKDTO
            {
                Id = x.Id,
                Name =x.Name,
                IBAN = x.IBAN,
                Address =x.Address,
                PhoneNumber=x.PhoneNumber
            });
              
        }


    }
}
