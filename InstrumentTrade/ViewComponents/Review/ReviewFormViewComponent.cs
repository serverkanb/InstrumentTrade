using InstrumentTrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentTrade.WebUI.ViewComponents.Review
{
    public class ReviewFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int productId)
        {
            var model = new ReviewInputModel { ProductId = productId };
            return View(model);
        }
    }
}
