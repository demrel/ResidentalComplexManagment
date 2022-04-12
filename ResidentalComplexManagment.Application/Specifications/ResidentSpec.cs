using Ardalis.Specification;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications
{
    public  class ResidentSpec : Specification<Resident, ResidentDTO>
    {
        public ResidentSpec()
        {
            Query.Select(x => new ResidentDTO
            {
               Id= x.Id,
               Name=x.Name,
               Surname=x.Surname,
               FIN=x.FIN,
               PhoneNumber=x.PhoneNumber,
               Birthday=x.Birthday,
               IsCurrentResident=x.IsCurrentResident,
               AppartmentId=x.AppartmentId,
               AppartmentName = x.Appartment.Name,
               Created=x.Created,
               BuildingName=x.Appartment.Building.Name,
               MKTName = x.Appartment.Building.MKT.Name,
            }).OrderByDescending(c=>c.Created);
              
        }

        public ResidentSpec(string id)
        {
            Query.Select(x => new ResidentDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                FIN = x.FIN,
                PhoneNumber = x.PhoneNumber,
                Birthday = x.Birthday,
                IsCurrentResident = x.IsCurrentResident,
                Created = x.Created,
            }).Where(c => c.AppartmentId == id);

        }



    }
}
