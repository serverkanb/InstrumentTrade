using System.ComponentModel.DataAnnotations;

namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class ChangePaswordViewModel
    {
        public class ChangePasswordViewModel
        {
            [Required]
            public string OldPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
        }
    }
}
