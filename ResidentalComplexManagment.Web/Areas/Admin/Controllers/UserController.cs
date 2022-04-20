using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseAdminController
    {
        private readonly IUser _userService;
        private readonly IMTK _mtkService;

        public UserController(IUser userService, IMTK mtkService)
        {
            _userService = userService;
            _mtkService = mtkService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetList();
            UserIndexVM model = new()
            {
                Users = users,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var mkts = await _mtkService.GetSelectList();
            UserAddVM model = new()
            {
                MTKs = new SelectList(mkts, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name)),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddVM model)
        {
            await _userService.Add(model.Add, model.Password);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SeedRole()
        {
           await _userService.SeedRoles();
            return Ok("seeded...");
        }
        public async Task<IActionResult> Update(string id)
        {
            var mkts = await _mtkService.GetSelectList();
            var user = await _userService.GetById(id);
            UserAddVM model = new()
            {
                MTKs = new SelectList(mkts, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name)),
                Add = user,
            };
            return View(model);
        }

        public async Task<IActionResult> Update(UserAddVM model)
        {
            await _userService.Update(model.Add, model.Password);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deactivate()
        {
            return View();
        }


    }
}
