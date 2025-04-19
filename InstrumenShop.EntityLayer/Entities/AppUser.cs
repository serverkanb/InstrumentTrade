using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
     public class  AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [StringLength(1000)]
        public string? Address { get; set; }

        public int? CountryId { get; set; }      // ❗ Nullable
        public Country Country { get; set; }

        public int? CityId { get; set; }         // ❗ Nullable
        public City City { get; set; }
 
        public bool IsActive { get; set; }

        public List<Order> Orders { get; set; }
    }
}
