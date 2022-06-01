using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Web.Areas.Admin.Models;
using System.Security.Claims;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class BuildingController : BaseAdminController
    {
        private readonly IBuilding _buildingService;
        private readonly IAppartment _appartmentService;
        private readonly IMTK _mtkService;
        private readonly ICurrentUserService _currentUserService;

        public BuildingController(IBuilding buildingService, IMTK mtkService, IAppartment appartmentService, ICurrentUserService currentUserService)
        {
            _buildingService = buildingService;
            _mtkService = mtkService;
            _appartmentService = appartmentService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search="",int page=1,int size=30)
        {
            string userId = _currentUserService.GetNonAdminUserId;
            var buildings = await _buildingService.GetList(userId,search,page, size);
            var model = new BuildingIndexVM()
            {
                Buildings = buildings,
                FilterParameter =search,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string id)
        {
            string userId = _currentUserService.GetNonAdminUserId;
            var mtkList = await _mtkService.GetSelectList(userId);
            BuildingAddVM buildingAddVM = new()
            {
                Mkt = new SelectList(mtkList, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name), id)
            };
            return View(buildingAddVM);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, string search = "", int page = 1, int size = 30)
        {

            var building = await _buildingService.GetById(id);
            if (building == null) return NotFound();

            var appartments = await _appartmentService.GetAppartmentsByBuilding(id, search, page, size);
            var model = new BuildingGetVM()
            {
                Building = building,
                Appartments = appartments,
                FilterParameter=search,
            };
            return View(model);
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
            string userId = _currentUserService.GetNonAdminUserId;

            var building = await _buildingService.GetById(id);
            if (building == null) return NotFound();

            var mktList = await _mtkService.GetSelectList(userId);

            BuildingAddVM buildingAddVM = new()
            {
                Mkt = new SelectList(mktList, nameof(SelectListItemDto.Id), nameof(SelectListItemDto.Name), building.MKTId),
                Add = building,
            };
            return View(buildingAddVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildingList(string id)
        {
            var building = await _buildingService.GetSelectList(id);
            return Ok(building);
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
