using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class ResidentController : BaseAdminController
    {
        private readonly IResident _residentService;
        private readonly IMTK _mtkService;


        public ResidentController(IResident residentService, IMTK mtkService)
        {
            _residentService = residentService;
            _mtkService = mtkService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var residents=await _residentService.GetList();
            var model = new ResidentIndexVM()
            {
                Residents = residents,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var mkt = await _mtkService.GetSelectList();
            ResidentAddVM model = new()
            {
                Mkts = mkt,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddFromAppartment(string id)
        {

            ResidentAddVM model = new()
            {
                Add = new ResidentDTO() { AppartmentId = id },
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ResidentAddVM model, string  redirect)
        {
            await _residentService.Add(model.Add);
            if (string.IsNullOrEmpty(redirect)) return RedirectToAction("Index");
            else return RedirectToAction(redirect,new {id=model.Add.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var resident = await _residentService.GetById(id);
            if (resident == null) return NotFound();
            ResidentUpdateVM model = new()
            {
                Add = resident,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResidentUpdateVM model)
        {
            await _residentService.Update(model.Add);
            return  RedirectToAction("Index");
        }
    }
}
