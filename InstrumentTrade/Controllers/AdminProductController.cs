using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _productService.TGetProductsWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productService.TDelete(id);
            return RedirectToAction("Index");
        }
        // CREATE (GET)
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.TGetList(); // Veritabanından çek
            

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //

            _productService.TCreate(product);
            return RedirectToAction("Index");
        }

        // UPDATE (GET)
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
                return NotFound();

            ViewBag.Categories = new SelectList(
                _categoryService.TGetList(), "Id", "Name", value.CategoryId);

            return View(value);
        }

        // UPDATE (POST)
        [HttpPost]
        public IActionResult Update(Product product)
        {
            var value = _productService.TGetById(product.ProductId);
            if (value == null)
                return NotFound();

            value.Name = product.Name;
            value.Description = product.Description;
            value.ImageUrl = product.ImageUrl;
            value.Price = product.Price;
            value.StockAmount = product.StockAmount;
            value.CategoryId = product.CategoryId;

            _productService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
