using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public AppUser AppUser { get; set; }
        
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Createdate{ get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
