using Newtonsoft.Json;

namespace KrisNikShopProject.Components.Data
{
    public class OrderStorageService
    {

        private readonly UserRegistrationService userRegistrationService;
        private readonly ProductStorageService productStorageService;
        private readonly string FILE_PATH;

        public OrderStorageService(UserRegistrationService userRegistrationService, ProductStorageService productStorageService)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            FILE_PATH = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "UsersOrders"));
            this.userRegistrationService = userRegistrationService;
            this.productStorageService = productStorageService;
            //In this code, the CartStorageService constructor takes a UserRegistrationService parameter,
            //which is provided by the dependency injection system. The parameter is assigned to the _userRegistrationService field,
            //which can then be used throughout the CartStorageService class.
        }

        public void AddOrder(OrderModel product)
        {
            if (userRegistrationService.CurrentUser != null)
            {
                string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService.CurrentUser.Id}_orders.txt");


                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    product.Id =  1;
                }
                else
                {
                    int? maxId = GetAllOrders().Max(order => order.Id);
                    product.Id = maxId.GetValueOrDefault() + 1;
                    
                }

                string info = JsonConvert.SerializeObject(product);
                
                using (var sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(info);
                }
            }
        }

        public List<OrderModel> GetAllOrders()
        {
            // Need to count the quantity of items that have the same id

            List<OrderModel> orders = new List<OrderModel>();

            string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService?.CurrentUser?.Id ?? 0}_orders.txt");

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        OrderModel? order = JsonConvert.DeserializeObject<OrderModel>(line);
                        orders.Add(order!);
                    }
                }
            }

            return orders;
        }

        public List<OrderModel> GetAllOrders(UserModel user)
        {
            // Need to count the quantity of items that have the same id

            List<OrderModel> orders = new List<OrderModel>();

            string fileName = Path.Combine(FILE_PATH, $"{user.Id}_orders.txt");

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        OrderModel? order = JsonConvert.DeserializeObject<OrderModel>(line);
                        orders.Add(order!);
                    }
                }
            }

            return orders;
        }

        public OrderModel? GetOrder(int? ID, UserModel user)
        {
            List<OrderModel> orders = GetAllOrders(user);
            return orders.FirstOrDefault(order => order.Id == ID);
        }

        public void DeleteOrder(UserModel user)
        {
            string fileName = Path.Combine(FILE_PATH, $"{user.Id}_orders.json");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
