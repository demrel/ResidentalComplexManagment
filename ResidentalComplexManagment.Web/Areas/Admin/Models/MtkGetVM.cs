using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class MtkGetVM
    {
        public MTKDTO MTK { get; set; }
        public List<BuildingDTO> Buildings { get; set; }
    }
}
