using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InstrumentTrade.WebUI.ViewComponents.Review
{
    public class ReviewFormViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;

        public ReviewFormViewComponent(UserManager<AppUser> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var model = new ReviewInputModel { ProductId = productId };

            var user = await _userManager.GetUserAsync((ClaimsPrincipal)User);
            if (user == null)
            {
                ViewBag.CanReview = false;
                return View(model);
            }

            // Siparişlerinde bu ürünü almış mı kontrol et
            var orders = _orderService.TGetOrdersByUserId(user.Id); 
            bool hasProduct = orders
                .SelectMany(o => o.OrderItems)
                .Any(oi => oi.ProductId == productId);

            ViewBag.CanReview = hasProduct;

            return View(model);
        }
    }
}
