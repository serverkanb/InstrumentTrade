using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public RegisterController(UserManager<AppUser> userManager, ICountryService countryService, ICityService cityService)
        {
            _userManager = userManager;
            _countryService = countryService;
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name", model.CountryId);
                ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name", model.CityId);
                return View(model);
            }

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address,
                CountryId = model.CountryId,
                CityId = model.CityId,
                
             
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name", model.CountryId);
            ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name", model.CityId);
            return View(model);
        }
    }
}