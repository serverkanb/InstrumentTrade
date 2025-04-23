using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; } // IdentityUser ile ilişkilendirme
        public AppUser AppUser { get; set; }

        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Hazırlanıyor, Kargoda, Teslim Edildi gibi
        public DateTime CreatedAt { get; set; } = DateTime.Now;//Siparişin oluşturuğu tarihi otomatik alsın diye

        public string FullAddress { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
