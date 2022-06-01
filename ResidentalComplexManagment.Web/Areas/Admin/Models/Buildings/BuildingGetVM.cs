using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class BuildingGetVM
    {
        public BuildingDTO Building { get; set; }
        public PaginationList<AppartmentDTO> Appartments { get; set; }
        public string FilterParameter { get; set; }
    }
}
