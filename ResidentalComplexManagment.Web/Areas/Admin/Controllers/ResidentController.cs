using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models.Residents;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class ResidentController : BaseAdminController
    {
        private readonly IResident _residentService;
        private readonly IMTK _mtkService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDebtItem _debtItemService;



        public ResidentController(IResident residentService, IMTK mtkService, ICurrentUserService currentUserService, IDebtItem debtItemService)
        {
            _residentService = residentService;
            _mtkService = mtkService;
            _currentUserService = currentUserService;
            _debtItemService = debtItemService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = _currentUserService.GetNonAdminUserId;
            var residents = await _residentService.GetList();
            var model = new ResidentIndexVM()
            {
                Residents = residents,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = _currentUserService.GetNonAdminUserId;
            var mkt = await _mtkService.GetSelectList(userId);
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
        public async Task<IActionResult> Add(ResidentAddVM model, string redirect)
        {
            await _residentService.Add(model.Add);
            if (string.IsNullOrEmpty(redirect)) return RedirectToAction("Index");
            else return RedirectToAction(redirect, new { id = model.Add.Id });
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
            return RedirectToAction("Index");
        }

        [HttpGet("[area]/[controller]/[action]/{residentId}")]
        public async Task<IActionResult> AddDebtItem(string residentId)
        {
            var debtItems = await _residentService.GetDebtItems(residentId);
            if (debtItems == null) return NotFound();

            var model = new ResidentAddDebtItemsVM()
            {
                DebtItems = debtItems,
                ResidentId = residentId,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDebtItem(ResidentAddDebtItemsVM model)
        {
            await _residentService.AddOrRemoveDebtItems(model.DebtItems,model.ResidentId);
            return RedirectToAction("index");
        }
    }
}
