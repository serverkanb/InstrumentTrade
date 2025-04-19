using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public AdminUserController(UserManager<AppUser> userManager, ICityService cityService, ICountryService countryService)
        {
            _userManager = userManager;
            _cityService = cityService;
            _countryService = countryService;
        }

        // Tüm kullanıcıları listeleme
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users
                .Include(u => u.City)
                .Include(u => u.Country)
                .ToList();

            ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name");
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "Id", "Name");

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> IsActive(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            return View(user); // sadece IsActive alanı içeren bir view dönmesini istiyoruz
        }

        [HttpPost]
        public async Task<IActionResult> IsActive(AppUser user)
        {
            var value = await _userManager.FindByIdAsync(user.Id.ToString());
            if (value == null)
                return NotFound();

            value.IsActive = user.IsActive;
            await _userManager.UpdateAsync(value);

            return RedirectToAction("Index");
        }

    }
}


