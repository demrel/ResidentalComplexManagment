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
    internal  class Buildingpecifiaction : Specification<Building, BuildingDTO>
    {
        public Buildingpecifiaction()
        {
            Query.Select(x => new BuildingDTO
            {
               Id= x.Id,
               Name= x.Name,
               Created = x.Created,
               Address= x.Address,
               MKTName=x.MKT.Name,
               Number= x.Number,
               
            });
              
        }

        public Buildingpecifiaction(string mtkId)
        {
            Query.Select(x => new BuildingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Created = x.Created,
                Address = x.Address,
                MKTName = x.MKT.Name,
                Number = x.Number,

            }).Where(c=>c.MKTId==mtkId);
        }
    }
}
