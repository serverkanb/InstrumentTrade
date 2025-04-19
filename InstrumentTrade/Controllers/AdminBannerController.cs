using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public AdminBannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _bannerService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBanner(Banner banner)
        {
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var value = _bannerService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBanner(Banner banner)
        {
            _bannerService.TUpdate(banner);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBanner(int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }
    }

}
