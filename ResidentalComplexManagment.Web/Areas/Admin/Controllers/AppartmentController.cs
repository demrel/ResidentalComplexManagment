using Microsoft.AspNetCore.Authorization;
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
        private readonly IResident _residentService;
        private readonly ICurrentUserService _currentUserService;


        public AppartmentController(IBuilding buildingService, IMTK mtkService, IAppartment appartmentService, IResident residentService, ICurrentUserService currentUserService)
        {
            _buildingService = buildingService;
            _mtkService = mtkService;
            _appartmentService = appartmentService;
            _residentService = residentService;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _currentUserService.GetNonAdminUserId;
            var appartments = await _appartmentService.GetList(userId);
            var model = new AppartmentIndexVM()
            {
                Appartments = appartments,
            };
            return View(model);
        }

        public async Task<IActionResult> Get(string id)
        {
            var appartment = await _appartmentService.GetById(id);
            if (appartment == null) return NotFound();
            var residents = await _residentService.GetResidentsByAppartment(id);

            var model = new AppartmentGetVM()
            {
                Appartment = appartment,
                Residents= residents,
            };
            return View(model);
        }

        public async Task<IActionResult> GetAppartmentList(string id)
        {
            var appartments=await _appartmentService.GetSelectList(id);
            return Ok(appartments);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = _currentUserService.GetNonAdminUserId;

            var mkt = await _mtkService.GetSelectList(userId);
            AppartmentAddVM AppartmentAddModel = new()
            {
                Mkts = mkt,
            };
            return View(AppartmentAddModel);
        }

        [HttpGet]
        public  IActionResult AddFromBuilding(string id)
        {

            AppartmentAddVM AppartmentAddModel = new()
            {
              Add = new AppartmentDTO() { BuildingId = id },
            };
           
            
            return View(AppartmentAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppartmentAddVM model,bool redirect)
        {

            await _appartmentService.Add(model.Add);
            if (redirect) return RedirectToAction("Index");
            else return RedirectToAction("Add");

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            string userId = _currentUserService.GetNonAdminUserId;

            var appartment = await _appartmentService.GetById(id);
            var mktList = await _mtkService.GetSelectList(userId);
            var buildingList = await _buildingService.GetSelectList(appartment.MtkId);

            AppartmentUpdateVM apartmentUpdateModel = new()
            {
               Mkts=mktList,
               Buildings= buildingList,
               Add=appartment
            };
            return View(apartmentUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppartmentUpdateVM model)
        {
            await _appartmentService.Update(model.Add);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _appartmentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
