using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentIndexVM
    {
        public PaginationList<AppartmentDTO> Appartments { get; set; }
        public string FilterParameter { get; set; }
    }
}
