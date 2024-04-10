namespace KrisNikShopProject.Components.Data
{
    public class CartStorageService
    {
        private readonly UserRegistrationService userRegistrationService;
        private readonly ProductStorageService productStorageService;
        private readonly string FILE_PATH;
         
        public CartStorageService(UserRegistrationService userRegistrationService, ProductStorageService productStorageService)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
			FILE_PATH = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "UsersCarts"));
            this.userRegistrationService = userRegistrationService;
            this.productStorageService = productStorageService;
            //In this code, the CartStorageService constructor takes a UserRegistrationService parameter,
            //which is provided by the dependency injection system. The parameter is assigned to the _userRegistrationService field,
            //which can then be used throughout the CartStorageService class.
        }

        public void AddProduct(ProductModel product, int count = 1)
        {
            if (userRegistrationService.CurrentUser != null)
            {
                string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService.CurrentUser.Id}_cart.csv");

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                // Append the product to the file
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine($"{product.Id},{product.Name}"); 
                }
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

             string fileName = Path.Combine(FILE_PATH, $"{userRegistrationService?.CurrentUser?.Id ?? 0}_cart.csv");

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        ProductModel product = productStorageService.GetProductById(int.Parse(parts[0]));
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }
}
