using InstrumenShop.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public string Imageurl { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public string FullName { get; set; }

        public string FullAddress { get; set; }

        public int? CountryId { get; set; }

        public int? CityId{ get; set; }

        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Cities { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
