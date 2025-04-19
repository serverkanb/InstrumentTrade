using InstrumenShop.EntityLayer.Entities;

namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class CartViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
