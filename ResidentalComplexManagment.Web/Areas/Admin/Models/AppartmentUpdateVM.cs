using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class AppartmentUpdateVM
    {
        public AppartmentDTO Add { get; set; }
        public List<SelectListItemDto> Mkts { get; set; }
        public List<SelectListItemDto> Buildings { get; set; }

       
    }
}
