using System.Globalization;
using System.ComponentModel.DataAnnotations;
namespace KrisNikShopProject.Components.Data

{
    public class UserModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain 8-15 letters, 1 special character, 1 number, and 1 uppercase letter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }
        public string? Role { get; set; } = "User";
        public DateTime DateOfCreating { get; }
        public string? PhoneNumber { get; set; }
        public string? CardNumber {get; set;}
        public string? CardCVC2 {get; set;}
        public string? CardDate {get; set;}
        public string? CardNameSurname { get; set;}

		public UserModel()
        {
            DateOfCreating = DateTime.Now;
		}

        public UserModel(int id, string name, string password, string email, string role, DateTime dateOfCreating, string phoneNumber, string cardNumber, string cardCVC2, string cardDate, string cardNameSurname)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
            DateOfCreating = dateOfCreating;
            PhoneNumber = (phoneNumber.Trim() == "Unknown") ? null : phoneNumber.Trim();
            CardNumber = (cardNumber.Trim() == "Unknown") ? null : cardNumber.Trim();
            CardCVC2 = (cardCVC2.Trim() == "Unknown") ? null : cardCVC2.Trim();
            CardDate = (cardDate.Trim() == "Unknown") ? null : cardDate.Trim();
            CardNameSurname = (cardNameSurname.Trim() == "Unknown") ? null : cardNameSurname.Trim();
        }
        

        public override string ToString()
        {
			return  Id + "," + Name + "," + Password + "," + Email + "," + Role + "," + DateOfCreating.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("lv-LV")) + "," + (PhoneNumber?.Trim() ?? "Unknown") + "," + (CardNumber?.Trim() ?? "Unknown") + "," + (CardCVC2?.Trim() ?? "Unknown") + "," + (CardDate?.Trim() ?? "Unknown") + "," + (CardNameSurname?.Trim() ?? "Unknown");	
		}
    }
}
