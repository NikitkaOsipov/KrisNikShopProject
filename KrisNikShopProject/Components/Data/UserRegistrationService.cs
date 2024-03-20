using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;


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
                /* OnCurrentUserChanged?.Invoke(); */
            }
        }

        public event Action? OnCurrentUserChanged; //https://www.youtube.com/watch?v=jQgwEsJISy0&ab_channel=ProgrammingwithMosh

        private readonly string FILE_NAME;

        public UserRegistrationService()
        {
			string currentDirectory = Directory.GetCurrentDirectory();
			FILE_NAME = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "Users.csv"));
		}

        public Boolean RegisterUser(UserModel user)
        {
            UserModel? rightUser = GetUserEmail(user.Email!);
            if(rightUser == null) //checks if the user email is unique 
            {
                int? maxId = GetAllUsers().Max(user => user.Id);
                user.Id = maxId.GetValueOrDefault() + 1;
            
			    using (StreamWriter sw = new StreamWriter(FILE_NAME, true))
                {
                    sw.WriteLine(user.ToString());
                }
                CurrentUser = user;
                return true; // if the user email is unique return true
            }
            return false; // if the user email already exixts return false
        }

        public Boolean SignInUser(UserModel user)
        {
            UserModel? rightUser = GetUserEmail(user.Email!);
            if(rightUser != null && rightUser?.Password == user.Password) 
            {
                CurrentUser = rightUser;
                return true; // if user is registrated returns true
            }
            return false;//if user not registrated returns false
        }

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
                        line[3], line[4]));
				}
			}

            return users;
        }

        //public async Task<UserModel[]> GetAllUsersAsync()
        //{
        //    List<Task<UserModel>> tasks = new List<Task<UserModel>>();
        //    using (var reader = new StreamReader(FILE_NAME))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            tasks.Add(Task.Run(() =>
        //            {
        //                string[] line = reader.ReadLine()!.Split(",");
        //                return new UserModel(Int32.Parse(line[0]),
        //                        line[1], line[2], line[3], line[4]);
        //            }));
        //        }
        //    }

        //    var result = await Task.WhenAll(tasks);
        //    return result;
        //}


        public UserModel? GetUserEmail(string email)
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



        public string GetCurrentUserString()
        {
            string result = (CurrentUser?.Name ?? "Guest") + " " + (CurrentUser?.Email ?? "unknownEmail") + "!!!!";
			return result;
		}

        public string GetFileName()
        {
			return FILE_NAME;
		}

        public string GetUsersFromCsv()
        {
            return "User1,User2,User3";
        }
    }
}