using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.ViewComponents.Review
{
    public class ReviewListViewComponent : ViewComponent
    {
        private readonly IReviewService _reviewService;

        public ReviewListViewComponent(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var reviews = _reviewService.TGetReviewsWithUser(productId)
                .Select(r => new ReviewViewModel
                {
                    Author = r.AppUser?.Name + " " + r.AppUser?.Surname,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    Date = r.Createdate
                }).ToList();

            return View(reviews);
        }
    }
}
