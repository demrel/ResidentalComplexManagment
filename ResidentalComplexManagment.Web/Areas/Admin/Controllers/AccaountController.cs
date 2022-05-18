using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Infrastructure.IdentityEntity;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccaountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
      

        public AccaountController(SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
          
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName.Trim(), model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {

                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login və ya şifrə düzgün deyil");
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/home/index");
        }
    }
}
