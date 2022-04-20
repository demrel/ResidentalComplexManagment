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
    internal class IncludeALlParamsToAppartment: Specification<Appartment,AppartmentDTO>
    {
        public IncludeALlParamsToAppartment(string id)
        {
            Query.Select(x => new AppartmentDTO
            {
                Id = x.Id,
                DoorNumber = x.DoorNumber,
                Created = x.Created,
                Area = x.Area,
                MtkName = x.Building.MKT.Name,
                BuildingName = x.Building.Name,
                Name=x.Name
            }).Where(c => c.Id == id);
        }

    }
}
