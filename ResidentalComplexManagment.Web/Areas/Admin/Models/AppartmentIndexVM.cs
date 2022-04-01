using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentIndexVM
    {
        public List<AppartmentDTO> Appartments { get; set; }
        public AppartmentIndexVM()
        {
            Appartments = new();
        }
    }
}
