using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class ResidentIndexVM
    {
        public List<ResidentDTO> Residents { get; set; }
        public ResidentIndexVM()
        {
            Residents = new();
        }
    }
}
