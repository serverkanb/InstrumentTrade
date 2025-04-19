using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CategoryController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult CategoryDetail(int id, string search, string sort)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
                return NotFound();

            var products = _productService.TGetProductsWithCategory()
                .Where(p => p.CategoryId == id);

            if (!string.IsNullOrEmpty(search))
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower()));

            if (!string.IsNullOrEmpty(sort))
            {
                products = sort switch
                {
                    "asc" => products.OrderBy(p => p.Price),
                    "desc" => products.OrderByDescending(p => p.Price),
                    _ => products
                };
            }

            ViewBag.CategoryName = category.Name;
            ViewBag.CategoryId = id;

            return View(products.ToList());
        }

    }
}
