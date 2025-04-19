using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class Role 
    {
        public int RoleId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public List<User> Users { get; set; }

    }
}
