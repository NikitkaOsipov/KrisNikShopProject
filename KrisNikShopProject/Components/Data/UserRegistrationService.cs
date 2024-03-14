using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace KrisNikShopProject.Components.Data
{
    public class UserRegistrationService
    {
        public UserModel? currentUser { get; private set; }
        private readonly string FILE_NAME;

        public UserRegistrationService()
        {
			string currentDirectory = Directory.GetCurrentDirectory();
			FILE_NAME = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "Users.csv"));
		}

        public void RegisterUser(UserModel user)
        {
            int? maxId = GetAllUsers().Max(user => user.Id);
            user.Id = maxId.GetValueOrDefault() + 1;

			using (StreamWriter sw = new StreamWriter(FILE_NAME, true))
            {
				sw.WriteLine(user.ToString());
			}

            currentUser = user;
        }

        public void SignInUser(UserModel user)
        {
            UserModel? rightUser = GetUserEmail(user.Email!);
            if(rightUser != null && rightUser?.Password == user.Password) 
            {
                currentUser = rightUser;
            }
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
            string result = (currentUser?.Name ?? "Guest") + " " + (currentUser?.Email ?? "unknownEmail") + "!!!!";
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