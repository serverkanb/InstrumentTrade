using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Areas.Customer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static InstrumentTrade.WebUI.Areas.Customer.Models.ChangePaswordViewModel;

namespace InstrumentTrade.WebUI.Areas.Customer.Controllers
{

    [Area("Customer")]
    [Authorize(Roles = "Customer")]

    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public ProfileController(UserManager<AppUser> userManager, ICountryService countryService, ICityService cityService)
        {
            _userManager = userManager;
            _countryService = countryService;
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Console.WriteLine($"Name: {user?.Name}, Surname: {user?.Surname}");

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new CustomerEditViewModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Surname = user.Surname,

                UserName = user.UserName,
                Address = user.Address,
                //CountryId = user.CountryId,
                //CityId = user.CityId,
                //Countries = _countryService.TGetList().Select(x => new SelectListItem
                //{
                //    Text = x.Name,
                //    Value = x.CountryId.ToString()
                //}).ToList(),
                //Cities = _cityService.TGetList().Select(x => new SelectListItem
                //{
                //    Text = x.Name,
                //    Value = x.CityId.ToString()
                //}).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            //  SelectList'leri doldur
            //model.Countries = _countryService.TGetList()
            //    .Select(x => new SelectListItem
            //    {
            //        Text = x.Name,
            //        Value = x.CountryId.ToString()
            //    }).ToList();

            //model.Cities = _cityService.TGetList()
            //    .Select(x => new SelectListItem
            //    {
            //        Text = x.Name,
            //        Value = x.CityId.ToString()
            //    }).ToList();

            if (!ModelState.IsValid)
                return View(model);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Address = model.Address;
            //user.CountryId = model.CountryId;
            //user.CityId = model.CityId;

            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Customer" });
            }

            foreach (var item in updateResult.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                ViewBag.Success = "Şifre başarıyla güncellendi.";
                return View();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


    }
}
