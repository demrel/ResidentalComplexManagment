using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models.DebtItems;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class DebtItemController : BaseAdminController
    {
        private readonly IDebtItem _debItemService;

        public DebtItemController(IDebtItem debItemService)
        {
            _debItemService = debItemService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _debItemService.GetList();
            DebtItemIndexVM model = new()
            {
                DebtItems = data,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(DebtItemAddVM model)
        {
            await _debItemService.Add(model.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _debItemService.GetById(id);
            DebtItemAddVM model = new DebtItemAddVM()
            {
                Add = data,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DebtItemAddVM model)
        {
            await _debItemService.Update(model.Add);
            return RedirectToAction("Index");
        }

    }
}
