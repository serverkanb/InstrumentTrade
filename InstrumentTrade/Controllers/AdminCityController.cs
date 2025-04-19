using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCityController : Controller
    {
        private readonly ICityService _cityService;

        public AdminCityController(ICityService cityService)
        {
            _cityService = cityService;
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
            return View();
        }

        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            _cityService.TCreate(city);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCity(int id)
        {
            var value = _cityService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCity(City city)
        {
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
