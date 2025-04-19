using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.Areas.Customer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
