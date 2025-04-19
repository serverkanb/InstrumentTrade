using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly UserManager<AppUser> _userManager;

        public AdminOrderController(IOrderService orderService, ICountryService countryService, ICityService cityService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _countryService = countryService;
            _cityService = cityService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var orders = _orderService.TGetOrdersWithDetails().OrderByDescending(o => o.CreatedAt)
                .ToList();

            return View(orders);
        }
        
        public IActionResult Detail(int id)
        {
            var order = _orderService.TGetOrderWithItems(id);
            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var order = _orderService.TGetById(id);
            if (order == null)
                return NotFound();

            
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name", order.CountryId);
            ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name", order.CityId);
            ViewBag.Users = new SelectList(_userManager.Users.ToList(), "Id", "UserName", order.UserId);


            return View(order);
        }

        [HttpPost]
        public IActionResult Update(Order order)
        {
            var value = _orderService.TGetById(order.OrderId);
            if (value == null)
                return NotFound();

            value.Status = order.Status;
            value.FullAddress = order.FullAddress;
            value.CityId = order.CityId;
            value.CountryId = order.CountryId;
            value.UserId = order.UserId;

            _orderService.TUpdate(value);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
       
            _orderService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
