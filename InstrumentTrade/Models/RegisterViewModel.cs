using System.ComponentModel.DataAnnotations;

namespace InstrumentTrade.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad boş geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public string? ImageUrl { get; set; }
    }
}
