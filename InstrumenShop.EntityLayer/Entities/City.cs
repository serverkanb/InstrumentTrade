using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumenShop.EntityLayer.Entities
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}
