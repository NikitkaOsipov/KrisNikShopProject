
namespace KrisNikShopProject.Components.Data
{
    public class UserModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public string? Role { get; set; }

        public UserModel()
        {
		}

		public UserModel(string id, string name, string password, string email, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
