using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class BuildingGetVM
    {
        public BuildingDTO Building { get; set; }
        public List<AppartmentDTO> Appartments { get; set; }
    }
}
