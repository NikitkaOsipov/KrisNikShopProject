using System.Globalization;


namespace KrisNikShopProject.Components.Data
{
    public class UserRegistrationService
    {
        private UserModel? _currentUser;
        public UserModel? CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                OnCurrentUserChanged?.Invoke();
            }
        }

        public event Action? OnCurrentUserChanged; //https://www.youtube.com/watch?v=jQgwEsJISy0&ab_channel=ProgrammingwithMosh

        private readonly string FILE_NAME;

        public UserRegistrationService()
        {
			string currentDirectory = Directory.GetCurrentDirectory();
			FILE_NAME = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "Users.csv"));
		}

        // This function registers a new user.
        public void RegisterUser(UserModel user)
        {
            UserModel? rightUser = GetUserByEmail(user.Email!);
            if(rightUser == null) //checks if the user email is unique 
            {
                int? maxId = GetAllUsers().Max(user => user.Id);
                user.Id = maxId.GetValueOrDefault() + 1;
            
			    using (StreamWriter sw = new StreamWriter(FILE_NAME, true))
                {
                    sw.WriteLine(user.ToString());
                }
                CurrentUser = user;
            }
            else
            {
                SignInUser(user);
            }
        }

        // This function signs in a user.
        public bool SignInUser(UserModel user)
        {
            UserModel? rightUser = GetUserByEmail(user.Email!);

            if(rightUser != null && rightUser?.Password == user.Password) 
            { 
                CurrentUser = rightUser;
                return true;
            }

            return false;
        }

        // This function gets all registered users.
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (var reader = new StreamReader(FILE_NAME))
            {
				while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()!.Split(",");
					users.Add(new UserModel(Int32.Parse(line[0]), 
                        line[1], line[2], 
                        line[3], line[4],
                        DateTime.ParseExact(line[5], "MM/dd/yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("lv-LV")), line[6], line[7], line[8], line[9], line[10]));
				}
			}

            return users;
        }

        // This function gets a user by their email.
        public UserModel? GetUserByEmail(string email)
        {   
            UserModel? resultUser = null;
            List<UserModel> users = GetAllUsers();
            foreach(UserModel user in users)
            {
                if (email == user.Email)
                {
                    resultUser = user;
                }
            }
            return resultUser;
        }

        // This function gets a user by their ID.
        public UserModel? GetUserById(int id)
        {   
            UserModel? resultUser = null;
            List<UserModel> users = GetAllUsers();
            foreach(UserModel user in users)
            {
                if (id == user.Id)
                {
                    resultUser = user;
                }
            }
            return resultUser;
        }

        // This function changes the data of a user.
        public void ChangeUserData(UserModel changeDataUser)
        {
            List<UserModel> users = GetAllUsers();

            for (int i = 0; i < users.Count; i++) // Find user and change it's data
            {
                if (users[i].Id == changeDataUser.Id)
                {
                    users[i] = changeDataUser;
                }
            }

            using (StreamWriter sw = new StreamWriter(FILE_NAME)) // rewrite all users
            {
                foreach (UserModel user in users)
                {
                    sw.WriteLine(user.ToString());
                }
            }

            if (CurrentUser?.Id == changeDataUser.Id)
                CurrentUser = changeDataUser;
        }

        // This function deletes a user.
        public void DeleteUser(UserModel userToDelete)
        {
            List<UserModel> users = GetAllUsers();

            foreach (UserModel user in users)
            {
                if (user.Id == userToDelete.Id)
                {
                    users.Remove(user);
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(FILE_NAME)) // rewrite all users
            {
                foreach (UserModel user in users)
                {
                    sw.WriteLine(user.ToString());
                }
            }

            if (CurrentUser?.Email == userToDelete.Email)
            {
                CurrentUser = null;
            }
        }

        // This function signs out the current user.
        public void SignOutUser() => CurrentUser = null;
    }
}