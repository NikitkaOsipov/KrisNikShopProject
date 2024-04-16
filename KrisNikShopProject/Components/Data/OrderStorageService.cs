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
                string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService.CurrentUser.Id}_orders.csv");

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                string info = JsonConvert.SerializeObject(product);

                using (var sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(info);
                }
            }
        }

        // public void DeleteCart(int? ID)
        // {
        //     if (userRegistrationService.CurrentUser != null)
        //     {
        //         string fileName = Path.Combine(FILE_PATH, $"{ID}_cart.csv");

        //         if (File.Exists(fileName))
        //         {
        //             File.Delete(fileName);
        //         }
        //     }
        // }

        // public void RemoveFromCarts(ProductModel product, int count = 1)
        // {
        //     if (userRegistrationService.CurrentUser != null)
        //     {
        //         string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService.CurrentUser.Id}_orders.csv");

        //         List<ProductModel>? cartProducts = GetAllProducts();


        //         if (cartProducts.FirstOrDefault(p => p.Id == product.Id) != null)
        //         {
        //             ProductModel? productToChange = cartProducts.FirstOrDefault(p => p.Id == product.Id);
        //             productToChange.Quantity -= count;

        //             if (productToChange.Quantity <= 0)
        //             {
        //                 cartProducts.Remove(productToChange);
        //             }

        //             using (var sw = new StreamWriter(fileName))
        //             {

        //                 foreach (ProductModel? p in cartProducts)
        //                 {
        //                     sw.WriteLine($"{p.Id},{p.Quantity}");
        //                 }
        //             }
        //         }
        //     }
        // }


        // public List<OrderModel> GetAllProducts()
        // {
        //     // Need to count the quantity of items that have the same id

        //     List<OrderModel> products = new List<OrderModel>();

        //     string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService?.CurrentUser?.Id ?? 0}_orders.csv");

        //     if (File.Exists(fileName))
        //     {
        //         using (var reader = new StreamReader(fileName))
        //         {
        //             string? line;
        //             while ((line = reader.ReadLine()) != null)
        //             {
        //                 string[] parts = line.Split(',');
        //                 ProductModel? product = productStorageService.GetProductById(int.Parse(parts[0]));
        //                 product!.Quantity = int.Parse(parts[1]);
        //                 products.Add(product);
        //             }
        //         }
        //     }

        //     return products;
        // }
    }
}
