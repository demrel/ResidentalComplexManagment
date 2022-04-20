﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseAdminController : Controller
    {
    }
}
