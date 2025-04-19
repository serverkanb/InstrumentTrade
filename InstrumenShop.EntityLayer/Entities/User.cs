using InstrumenShop.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }



        public Sex? Sex { get; set; }

        [StringLength(250)]
        public string? Email { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        public int? CountryId { get; set; }      // ❗ Nullable
        public Country Country { get; set; }

        public int? CityId { get; set; }         // ❗ Nullable
        public City City { get; set; }
    }
}
