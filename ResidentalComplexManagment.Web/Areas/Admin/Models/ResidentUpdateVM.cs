using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class ResidentUpdateVM
    {
        public ResidentDTO Add { get; set; }
        public List<SelectListItemDto> Mkts { get; set; }
        public List<SelectListItemDto> Buildings { get; set; }
        public List<SelectListItemDto> Appartments { get; set; }



    }
}
