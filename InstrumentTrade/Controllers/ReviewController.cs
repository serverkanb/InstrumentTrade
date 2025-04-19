using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [AllowAnonymous]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(IReviewService reviewService, UserManager<AppUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(ReviewInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ProductDetail", "ProductDetail", new { id = model.ProductId });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var review = new Review
            {
                ProductId = model.ProductId,
                Comment = model.Comment,
                Rating = model.Rating,
                AppUser = user,
                UserId = user.Id,
                Createdate = DateTime.Now
            };
       
            _reviewService.TCreate(review);

            return RedirectToAction("ProductDetail", "ProductDetail", new { id = model.ProductId });
        }
    }

}
