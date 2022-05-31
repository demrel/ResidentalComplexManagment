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
    public class Buildingpecifiaction : Specification<Building, BuildingDTO>
    {
        public Buildingpecifiaction(string filter = "")
        {
            Query.Select(x => new BuildingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Created = x.Created,
                Address = x.Address,
                MKTName = x.MKT.Name,
                Number = x.Number,

            }).Search(x => x.Name, $"%{filter}%")
              .Search(x => x.Address, $"%{filter}%")
              .Search(x => x.MKT.Name, $"%{filter}%")
              .Search(x => x.Number.ToString(), $"%{filter}%")
              .AsNoTracking();

        }

        public Buildingpecifiaction(string mtkId, string filter = "",int currentPage=1,int pageItemSize=30)
        {
            Query.Select(x => new BuildingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Created = x.Created,
                Address = x.Address,
                MKTName = x.MKT.Name,
                Number = x.Number,

            });

            if (!string.IsNullOrEmpty(mtkId))
                Query.Where(c => c.MKTId == mtkId);



            if (!string.IsNullOrEmpty(filter))
            {
                Query.Search(x => x.Name, $"%{filter}%")
                     .Search(x => x.Address, $"%{filter}%")
                     .Search(x => x.MKT.Name, $"%{filter}%")
                     .Search(x => x.Number.ToString(), $"%{filter}%");
            }
            Query.Skip(pageItemSize*(currentPage-1)).Take(pageItemSize).AsNoTracking();
        }
    }
}
