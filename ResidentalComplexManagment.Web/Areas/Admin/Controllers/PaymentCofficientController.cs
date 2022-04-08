using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class PaymentCofficientController : BaseAdminController
    {
        private readonly IPaymentCofficient _paymentCofficientService;

        public PaymentCofficientController(IPaymentCofficient paymentCofficientService)
        {
            _paymentCofficientService = paymentCofficientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var paymentCofficients= await _paymentCofficientService.GetAll();
            var model = new PaymentCofficientIndexVM()
            {
                PaymentCofficients = paymentCofficients
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentCoefficientDTO model)
        {
             await  _paymentCofficientService.Add(model);
            return RedirectToAction("Index");
        }
    }
}
