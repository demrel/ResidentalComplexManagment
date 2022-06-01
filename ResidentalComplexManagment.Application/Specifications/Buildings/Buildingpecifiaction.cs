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
            filter=filter.Trim().ToLower();
            Query.Select(x => new BuildingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Created = x.Created,
                Address = x.Address,
                MKTName = x.MKT.Name,
                Number = x.Number,

            }).Search(x => x.Name.ToLower(), $"%{filter}%")
              .Search(x => x.Address.ToLower(), $"%{filter}%")
              .Search(x => x.MKT.Name.ToLower(), $"%{filter}%")
              .Search(x => x.Number.ToString(), $"%{filter}%")
              .AsNoTracking();

        }

        public Buildingpecifiaction(string mtkId, string filter = "",int currentPage=1,int pageItemSize=30)
        {
            filter = filter.Trim().ToLower();

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
                Query.Search(x => x.Name.ToLower(), $"%{filter}%")
                     .Search(x => x.Address.ToLower(), $"%{filter}%")
                     .Search(x => x.MKT.Name.ToLower(), $"%{filter}%")
                     .Search(x => x.Number.ToString().ToLower(), $"%{filter}%");
            }
            Query.Skip(pageItemSize*(currentPage-1)).Take(pageItemSize).AsNoTracking();
        }
    }
}
