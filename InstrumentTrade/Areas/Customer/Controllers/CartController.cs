using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Areas.Customer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")] 
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _appUserManager;

        public CartController(ICartService cartService, UserManager<AppUser> appUserManager)
        {
            _cartService = cartService;
            _appUserManager = appUserManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _appUserManager.GetUserAsync(User);
            var cart = _cartService.TGetCartByUserId(user.Id);

            var viewModel = new CartViewModel
            {
                FullName = $"{user.Name} {user.Surname}",
                Address = user.Address,
                CityName = user.City?.Name,
                CountryName = user.Country?.Name,
                CartItems = cart.Items,
                TotalPrice = cart.Items.Sum(x => x.Quantity * x.Product.Price)
            };

            return View(viewModel);
        }
    

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _appUserManager.GetUserAsync(User);
            _cartService.TAddToCart(user.Id, productId, 1);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var user = await _appUserManager.GetUserAsync(User);
            _cartService.TRemoveFromCart(user.Id, productId);
            return RedirectToAction("Index");
        }
    }
}

