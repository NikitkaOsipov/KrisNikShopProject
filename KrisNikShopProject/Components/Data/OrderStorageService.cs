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
                string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService.CurrentUser.Id}_orders.json");


                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    product.Id =  1;
                }
                else
                {
                    int? maxId = 0;

                    foreach (OrderModel order in GetAllOrders())
                    {
                        if (order.Id >= maxId)
                        {
                            maxId = order.Id;
                        }
                    }

                    product.Id = maxId.GetValueOrDefault() + 1;
                }

                List<OrderModel> ordersToAdd = GetAllOrders() ?? new List<OrderModel>();

                ordersToAdd.Add(product);

                string ordersToWrite = JsonConvert.SerializeObject(ordersToAdd, Formatting.Indented);

                using (var sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(ordersToWrite);
                }
            }
        }

        public List<OrderModel> GetAllOrders()
        {
            string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService?.CurrentUser?.Id ?? 0}_orders.json");
            
            List<OrderModel> orders = new List<OrderModel>();

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(json);
            }

            return orders;
        }

        public List<OrderModel> GetAllOrders(UserModel user)
        {
            List<OrderModel> orders = new List<OrderModel>();

            string fileName = Path.Combine(FILE_PATH, $"{user.Id}_orders.json");

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(json);
            }
            
            return orders;
        }

        public OrderModel? GetOrder(int? ID, UserModel user)
        {
            List<OrderModel> orders = GetAllOrders(user);

            OrderModel orderToReturn = new OrderModel();

            foreach (OrderModel order in orders)
            {
                if (order.Id == ID)
                {
                    orderToReturn = order;
                }
            }

            return orderToReturn;
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
