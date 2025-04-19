using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class Cart
    {
        public int CartId { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<CartItem> Items { get; set;}
    }
}
