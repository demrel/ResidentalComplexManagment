using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class MtkGetVM
    {
        public MTKDTO MTK { get; set; }
        public PaginationList<BuildingDTO> Buildings { get; set; }
        public string FilterParameter { get; set; }
    }
}
