using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class CustomerEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
   
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        //public int? CountryId { get; set; }
        //public int? CityId { get; set; }

        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }

        //public List<SelectListItem> Countries { get; set; }
        //public List<SelectListItem> Cities { get; set; }
    }
}
