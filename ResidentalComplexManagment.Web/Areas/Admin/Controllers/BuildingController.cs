using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class BuildingController : BaseAdminController
    {
        private readonly IBuilding _buildingService;
        private readonly IMTK _mtkService;


        public BuildingController(IBuilding buildingService, IMTK mtkService)
        {
            _buildingService = buildingService;
            _mtkService = mtkService;
        }

        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingService.GetList();
            var model = new BuildingIndexVM()
            {
                Buildings = buildings,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string mtkId)
        {
            var mtkList = await _mtkService.GetMtkSelectList();
            BuildingAddVM buildingAddVM = new()
            {
                Mkt = new SelectList(mtkList, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name), mtkId)
            };
            return View(buildingAddVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BuildingAddVM model)
        {
            await _buildingService.Add(model.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var building = await _buildingService.GetById(id);
            var mktList = await _mtkService.GetMtkSelectList();
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
