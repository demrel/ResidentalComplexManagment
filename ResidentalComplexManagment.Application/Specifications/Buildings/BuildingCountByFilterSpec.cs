using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;

namespace ResidentalComplexManagment.Application.Specifications.Buildings;

public class BuildingCountByFilterSpec : Specification<Building>
{
    public BuildingCountByFilterSpec(string mtkId, string filter = "")
    {
        filter = filter.Trim().ToLower();

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

