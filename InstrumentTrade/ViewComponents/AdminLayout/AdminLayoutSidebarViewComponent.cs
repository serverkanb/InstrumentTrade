
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.ViewComponents.AdminLayout
{
    public class AdminLayoutSidebarViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
