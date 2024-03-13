
namespace KrisNikShopProject.Components.Data
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }

        public string? Role { get; set; } = "User";
		public UserModel()
        {
		}

		public UserModel(int id, string name, string password, string email, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

        public override string ToString()
        {
			return  Id + "," + Name + "," + Password + "," + Email + "," + Role;
		}
    }
}
