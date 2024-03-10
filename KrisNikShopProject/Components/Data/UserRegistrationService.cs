namespace KrisNikShopProject.Components.Data
{
    public class UserRegistrationService
    {
        public UserModel? currentUser { get; private set; }

        public void RegisterUser(UserModel user)
        {
            currentUser = user;
        }

        public string GetCurrentUser()
        {
            string result = (currentUser?.Name ?? "Guest") + " " + (currentUser?.Email ?? "unknownEmail") + "!!!!";
			return result;
		}
    }
}
