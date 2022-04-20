using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentGetVM
    {
        public AppartmentDTO Appartment { get; set; }
        public List<ResidentDTO> Residents { get; set; }
    }
}
