using System.ComponentModel.DataAnnotations;

namespace KrisNikShopProject.Components.Data
{
    public class CardInfoModel
    {
        [Required(ErrorMessage = "Card number is required")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must contain 16 digits")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "CVC is required")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CVC must contain 3 digits")]
        public string CVC { get; set; }

        [Required(ErrorMessage = "Expiry month is required")]
        public int ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Expiry year is required")]
        public int ExpiryYear { get; set; }

        [Required(ErrorMessage = "Name and surname is required")]
        public string NameSurname { get; set; }
    }
}
