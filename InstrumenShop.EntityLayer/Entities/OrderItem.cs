using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Ürünün sipariş anındaki fiyatı

        // Navigation property
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
