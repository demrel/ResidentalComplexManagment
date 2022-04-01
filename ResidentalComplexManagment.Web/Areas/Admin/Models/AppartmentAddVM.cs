using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentAddVM
    {
        public AppartmentDTO Add { get; set; }
        public SelectList Buildings { get; set; }
    }
}
