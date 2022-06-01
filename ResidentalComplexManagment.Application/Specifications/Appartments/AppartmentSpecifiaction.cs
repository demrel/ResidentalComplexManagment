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
        public AppartmentSpecifiaction(string filter = "", int currentPage = 1, int pageItemSize = 30)
        {
            filter = filter.Trim().ToLower();

            Query.Select(x => new AppartmentDTO
            {
               Id= x.Id,
               DoorNumber= x.DoorNumber,
               Created = x.Created,
               Area=x.Area,
               MtkName=x.Building.MKT.Name,
               BuildingName=x.Building.Name,

            });
            if (!string.IsNullOrEmpty(filter))
            {
                Query.Search(x => x.DoorNumber.ToString().ToLower(), $"%{filter}%")
                     .Search(x => x.Area.ToString().ToLower(), $"%{filter}%")
                     .Search(x => x.Building.MKT.Name.ToLower(), $"%{filter}%")
                     .Search(x => x.Building.Name.ToString().ToLower(), $"%{filter}%");
            }
            Query.Skip(pageItemSize * (currentPage - 1)).Take(pageItemSize).AsNoTracking();

        }

        public AppartmentSpecifiaction(string id, string filter = "", int currentPage = 1, int pageItemSize = 30)
        {
            filter = filter.Trim().ToLower();

            Query.Select(x => new AppartmentDTO
            {
                Id = x.Id,
                DoorNumber = x.DoorNumber,
                Created = x.Created,
                Area = x.Area,
                MtkName = x.Building.MKT.Name,
                BuildingName = x.Building.Name,
                BuildingId = x.Building.Id,
                MtkId = x.Building.MKT.Id,

            }).Where(c => c.BuildingId == id);

            if (!string.IsNullOrEmpty(filter))
            {
                Query.Search(x => x.DoorNumber.ToString().ToLower(), $"%{filter}%")
                     .Search(x => x.Area.ToString().ToLower(), $"%{filter}%");
            }
            Query.Skip(pageItemSize * (currentPage - 1)).Take(pageItemSize).AsNoTracking();

        }



    }
}
