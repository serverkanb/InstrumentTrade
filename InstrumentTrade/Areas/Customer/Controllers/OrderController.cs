using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Areas.Customer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(
            IOrderService orderService,
            ICartService cartService,
            ICountryService countryService,
            ICityService cityService,
            UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _countryService = countryService;
            _cityService = cityService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.TGetCartByUserId(user.Id);

            var viewModel = new OrderViewModel
            {
                FullName = user.Name + " " + user.Surname,
                FullAddress = user.Address,
                CountryId = user.CountryId ?? 0,
                CityId = user.CityId ?? 0,
                CreatedAt = DateTime.Now,
                TotalPrice = cart.Items.Sum(i => i.Product.Price * i.Quantity),
                CartItems = cart.Items,
                Countries = _countryService.TGetList().Select(c => new SelectListItem
                {
                    Value = c.CountryId.ToString(),
                    Text = c.Name
                }).ToList(),
                Cities = _cityService.TGetList().Select(c => new SelectListItem
                {
                    Value = c.CityId.ToString(),
                    Text = c.Name
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.TGetCartByUserId(user.Id);

            if (cart == null || cart.Items == null || !cart.Items.Any())
            {
                TempData["Error"] = "Sepetiniz boş, sipariş oluşturulamaz.";
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                UserId = user.Id,
                AppUser = user,
                FullAddress = model.FullAddress,
                CityId = model.CityId,
                CountryId = model.CountryId,
                CreatedAt = DateTime.Now,
                Status = "Hazırlanıyor",
                TotalPrice = cart.Items.Sum(i => i.Quantity * i.Product.Price),
                OrderItems = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Product.Price
                }).ToList()
            };

            _orderService.TCreate(order);
            _cartService.TClearCart(user.Id);

            return RedirectToAction("OrderDetail", new { id = order.OrderId });
        }

        // GET: Sipariş formu
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            ViewBag.Countries = new SelectList(_countryService.TGetList(), "CountryId", "Name");
            ViewBag.Cities = new SelectList(_cityService.TGetList(), "CityId", "Name");

            return View();
        }

        // POST: Sipariş oluştur
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order model)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.TGetCartByUserId(user.Id);

            if (cart == null || cart.Items == null || !cart.Items.Any())
            {
                TempData["Error"] = "Sepetiniz boş, sipariş verilemez.";
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                UserId = user.Id,
                FullAddress = model.FullAddress,
                CityId = model.CityId,
                CountryId = model.CountryId,
                CreatedAt = DateTime.Now,
                Status = "Hazırlanıyor",
                TotalPrice = cart.Items.Sum(i => i.Quantity * i.Product.Price),
                OrderItems = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Product.Price
                }).ToList()
            };

            _orderService.TCreate(order);
            _cartService.TClearCart(user.Id);

            return RedirectToAction("OrderList");
        }

        // GET: Sipariş geçmişi
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = _orderService.TGetList()
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();

            var viewModelList = orders.Select(order => new OrderViewModel
            {
                OrderId = order.OrderId,
                CreatedAt = order.CreatedAt,
                TotalPrice = order.TotalPrice,
                Status = order.Status
            }).ToList();

            return View(viewModelList);
        }

        // GET: Sipariş detayları
        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            var order = _orderService.TGetOrderWithItems(id);
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderViewModel
            {
                OrderId = order.OrderId,
                CreatedAt = order.CreatedAt,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                FullName = order.AppUser.Name +" "+order.AppUser.Surname,
                FullAddress = order.AppUser.Address,
                CityId = order.CityId,
                CountryId = order.CountryId,
                CartItems = order.OrderItems.Select(item => new CartItem
                {
                    Product = item.Product,
                    Quantity = item.Quantity
                }).ToList()
            };

            return View(viewModel);
        }
    }
}

