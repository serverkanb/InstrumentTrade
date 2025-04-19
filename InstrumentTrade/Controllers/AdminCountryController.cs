using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCountryController : Controller
    {
        private readonly ICountryService _countryService;

        public AdminCountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _countryService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            _countryService.TCreate(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCountry(int id)
        {
            var value = _countryService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCountry(Country country)
        {
            _countryService.TUpdate(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCountry(int id)
        {
            _countryService.TDelete(id);
            return RedirectToAction("Index");
        }
    }

}
