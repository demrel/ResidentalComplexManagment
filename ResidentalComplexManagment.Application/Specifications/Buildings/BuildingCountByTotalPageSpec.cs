using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications.Buildings
{
    public class BuildingCountByTotalPageSpec : Specification<Building>
    {
        public BuildingCountByTotalPageSpec(string mtkId, string filter = "")
        {
            if (!string.IsNullOrEmpty(mtkId))
                Query.Where(c => c.MKTId == mtkId);

            if (!string.IsNullOrEmpty(filter))
            {
                Query.Search(x => x.Name, $"%{filter}%")
                     .Search(x => x.Address, $"%{filter}%")
                     .Search(x => x.MKT.Name, $"%{filter}%")
                     .Search(x => x.Number.ToString(), $"%{filter}%");
            }
            
        }
    }
}
