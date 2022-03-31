using Microsoft.AspNetCore.Mvc;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class MTKController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
