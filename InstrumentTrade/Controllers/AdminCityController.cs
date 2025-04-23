using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public AdminCityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _cityService.TGetCitiesWithCountry();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCity()
        {
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            _cityService.TCreate(city);
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCity(int id)
        {
            var value = _cityService.TGetById(id);
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCity(City city)
        {
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            _cityService.TUpdate(city);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCity(int id)
        {
            _cityService.TDelete(id);
            return RedirectToAction("Index");
        }
    }

}
