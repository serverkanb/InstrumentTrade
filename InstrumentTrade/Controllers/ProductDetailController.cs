using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [AllowAnonymous]
    public class ProductDetailController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductDetailController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null) return NotFound();
            var reviews = _reviewService.TGetReviewsWithUser(id);
            var viewModel = new ProductDetailViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.StockAmount,
            
            };
            ViewBag.AverageRating = _reviewService.TGetAverageRating(product.ProductId);
            ViewBag.TotalReviews = _reviewService.TGetReviewCount(product.ProductId);
            return View(viewModel);
        }


    }
}