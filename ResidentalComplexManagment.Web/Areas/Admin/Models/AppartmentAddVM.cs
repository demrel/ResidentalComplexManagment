using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentAddVM : BaseAddVM
    {
        public AppartmentDTO Add { get; set; }
       
    }
}
