using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.DataAccessLayer.Migrations;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model, string? returnUrl)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (result.Succeeded && user != null && user.IsActive)
            {

              

                var customerResult = await _userManager.IsInRoleAsync(user, "Customer");
                var adminResult = await _userManager.IsInRoleAsync(user, "Admin");
                if (customerResult == true)
                {

                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Default");
               
                }
                else if (adminResult == true)
                {
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Default");
                }

                else
                {
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Default");
                }




            }

            ModelState.AddModelError("", user != null && !user.IsActive
        ? "Hesabınız pasif durumda. Lütfen yöneticiyle iletişime geçin."
        : "Kullanıcı adı veya şifre yanlış");
            return View();
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }

}
