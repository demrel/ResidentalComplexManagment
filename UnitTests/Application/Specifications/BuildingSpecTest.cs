using Ardalis.Specification.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Application.Specifications;

public class BuildingSpecTest
{
    public void GetFilteredItemCollectionCount()
    {
        var spec = new Buildingpecifiaction("her");
        GetTestCollection()
            .AsQueryable()
            .Where(predicate: spec.WhereExpressions.FirstOrDefault().Filter);
    }

    private List<Building> GetTestCollection()
    {
        
        var catalogItemList = new List<Building>();

       

        return catalogItemList;
    }
}

