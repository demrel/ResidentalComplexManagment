using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class BuildingIndexVM
    {
        public List<BuildingDTO> Buildings { get; set; }
        public BuildingIndexVM()
        {
            Buildings = new ();
        }
    }
}
