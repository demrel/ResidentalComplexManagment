using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class BuildingAddVM
    {
        public BuildingDTO Add { get; set; }
        public SelectList Mkt { get; set; }
    }
}
