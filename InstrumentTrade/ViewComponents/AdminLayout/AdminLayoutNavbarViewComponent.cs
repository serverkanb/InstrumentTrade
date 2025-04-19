using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.ViewComponents.AdminLayout
{
    public class AdminLayoutNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
