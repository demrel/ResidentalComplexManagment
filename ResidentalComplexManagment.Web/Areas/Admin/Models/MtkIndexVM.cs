using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class MtkIndexVM
    {
        public List<MTKDTO> MKTs { get; set; }
        public MtkIndexVM()
        {
            MKTs = new List<MTKDTO>();
        }
    }
}
