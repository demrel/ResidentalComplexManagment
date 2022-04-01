using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class AppartmentController : BaseAdminController
    {
        private readonly IBuilding _buildingService;
        private readonly IMTK _mtkService;
        private readonly IAppartment _appartmentService;


        public AppartmentController(IBuilding buildingService, IMTK mtkService)
        {
            _buildingService = buildingService;
            _mtkService = mtkService;
        }

        public async Task<IActionResult> Index()
        {
            var appartments = await _appartmentService.GetList();
            var model = new AppartmentIndexVM()
            {
                Appartments = appartments,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string mtkId,string buildingId)
        {
            var buildingList = await _buildingService.GetBuildingSelectList(mtkId);
            BuildingAddVM buildingAddVM = new()
            {
                Mkt = new SelectList(buildingList, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name), buildingId)
            };
            return View(buildingAddVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppartmentAddVM model)
        {
            await _appartmentService.Add(model.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var appartment = await _appartmentService.GetById(id);
            var mktList = await _buildingService.GetBuildingSelectList(appartment.Id);
            BuildingAddVM buildingAddVM = new()
            {
                Mkt = new SelectList(mktList, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name), building.MKTId),
                Add=building,
            };
            return View(buildingAddVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BuildingAddVM model)
        {
            await _buildingService.Update(model.Add);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _buildingService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
