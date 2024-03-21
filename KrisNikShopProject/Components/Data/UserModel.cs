
namespace KrisNikShopProject.Components.Data
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
        public string? Role { get; set; } = "User";
        public DateTime? DateOfCreating { get; }
        public string? PhoneNumber { get; set; }

		public UserModel()
        {
            DateOfCreating = DateTime.Now;
		}

		public UserModel(int id, string name, string password, string email, string role, DateTime dateOfCreating, string phoneNumber)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
            DateOfCreating = dateOfCreating;
            PhoneNumber = phoneNumber;
        }

        public UserModel(int id, string name, string password, string email, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
            DateOfCreating = DateTime.Now;
        }

        public override string ToString()
        {
			return  Id + "," + Name + "," + Password + "," + Email + "," + Role + "," + DateOfCreating + "," + (PhoneNumber ?? "Unknown");	
		}
    }
}
