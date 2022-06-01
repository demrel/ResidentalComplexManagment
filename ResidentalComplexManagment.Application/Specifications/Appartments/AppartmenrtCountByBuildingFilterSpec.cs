using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;


namespace ResidentalComplexManagment.Application.Specifications.Appartments;

internal class AppartmenrtCountByBuildingFilterSpec : Specification<Appartment>
{
    public AppartmenrtCountByBuildingFilterSpec(string mtkId, string filter = "")
    {
        filter = filter.Trim().ToLower();

        if (!string.IsNullOrEmpty(mtkId))
            Query.Where(c => c.Building.MKTId == mtkId);

        if (!string.IsNullOrEmpty(filter))
        {
            Query.Search(x => x.DoorNumber.ToString().ToLower(), $"%{filter}%")
                  .Search(x => x.Area.ToString().ToLower(), $"%{filter}%");
                
        }
    }
}

