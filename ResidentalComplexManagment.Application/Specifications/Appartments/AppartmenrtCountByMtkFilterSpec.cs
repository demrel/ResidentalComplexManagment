using Ardalis.Specification;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;


namespace ResidentalComplexManagment.Application.Specifications.Appartments;

internal class AppartmenrtCountByMtkFilterSpec : Specification<Appartment>
{
    public AppartmenrtCountByMtkFilterSpec(string buildingId, string filter = "")
    {
        filter = filter.Trim().ToLower();

        if (!string.IsNullOrEmpty(buildingId))
            Query.Where(c => c.BuildingId == buildingId);

        if (!string.IsNullOrEmpty(filter))
        {
            Query
                .Search(x => x.DoorNumber.ToString().ToLower(), $"%{filter}%")
                  .Search(x => x.Area.ToString().ToLower(), $"%{filter}%")
                  .Search(x => x.Building.MKT.Name.ToLower(), $"%{filter}%")
                  .Search(x => x.Building.Name.ToLower(), $"%{filter}%");
        }
    }
}

