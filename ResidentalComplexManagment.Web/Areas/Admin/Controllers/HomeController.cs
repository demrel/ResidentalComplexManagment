﻿using Microsoft.AspNetCore.Mvc;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
