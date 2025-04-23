using InstrumentShop.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Controllers
{
    [AllowAnonymous]
    public class AllProductController : Controller
    {
        private readonly IProductService _productService;

        public AllProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string search)
        {
            var products = _productService.TGetList();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(products);
        }
    }
}
