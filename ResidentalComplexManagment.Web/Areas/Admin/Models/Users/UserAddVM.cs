using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class UserAddVM
    {
        public UserDTO Add { get; set; }
        public SelectList MTKs { get; set; }
        public string Password { get; set; }
        public SelectList UserRoles =>new (Enum.GetValues(typeof(UserRoles)),Add?.Role);

  




    }
}
