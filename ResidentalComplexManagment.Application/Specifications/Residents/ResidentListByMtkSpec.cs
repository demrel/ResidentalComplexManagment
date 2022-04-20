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
    public class ResidentListByMtkSpec : Specification<Resident, ResidentDTO>
    {


        public ResidentListByMtkSpec(string mtkId)
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
            });
            if (!string.IsNullOrEmpty(mtkId))
            {
                Query.Where(c => c.Appartment.Building.MKTId == mtkId);
            }



        }



    }
}
