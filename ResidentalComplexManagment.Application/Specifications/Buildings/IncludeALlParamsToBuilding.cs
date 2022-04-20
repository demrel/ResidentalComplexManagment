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
    internal class IncludeALlParamsToBuilding: Specification<Building, BuildingDTO>
    {
        public IncludeALlParamsToBuilding(string id)
        {
            Query.Select(x => new BuildingDTO
            {
                Id = x.Id,
                Address = x.Address,
                Number = x.Number,
                Name = x.Name,
                Created = x.Created,
                MKTId = x.MKTId,
                MKTName = x.MKT.Name,
            }).Where(c => c.Id == id);
        }
    }
}
