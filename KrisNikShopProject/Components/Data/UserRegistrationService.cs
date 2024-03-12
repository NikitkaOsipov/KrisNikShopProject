namespace KrisNikShopProject.Components.Data
{
    public class UserRegistrationService
    {
        public UserModel? currentUser { get; private set; }

        public void RegisterUser(UserModel user)
        {
            currentUser = user;
        }

        public string GetCurrentUserString()
        {
            string result = (currentUser?.Name ?? "Guest") + " " + (currentUser?.Email ?? "unknownEmail") + "!!!!";
			return result;
		}

        public string GetUsersFromCsv()
        {
            return "User1,User2,User3";
        }
    }
}