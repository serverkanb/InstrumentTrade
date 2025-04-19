using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Areas.Customer.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
