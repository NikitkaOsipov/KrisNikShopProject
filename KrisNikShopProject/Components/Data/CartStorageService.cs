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

                ProductModel[]? existingProducts = GetAllProducts().ToArray();

                int productId = 0;

                for (int i = 0; i < existingProducts.Length; i++)
                {
                    if (existingProducts[i].Id == product.Id)
                    {
                        productId = i;
                    }
                }

                if(productId != 0)
                {
                    using (var sw = new StreamWriter(fileName))
                    {
                        existingProducts[productId].Quantity += count;
                        foreach (ProductModel? p in existingProducts)
                        {
                            sw.WriteLine($"{p.Id},{p.Quantity}");
                        }
                    }
                }
                else
                {
                    using (var sw = new StreamWriter(fileName, true))
                    {
                        sw.WriteLine($"{product.Id},{count}");
                    }
                }
            }
        }

        // This function deletes the cart of a user with a given ID.
        public void DeleteCart(UserModel user)
        {
            string fileName = Path.Combine(FILE_PATH, $"{user.Id}_cart.csv");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        // This function removes a specified quantity of a product from the cart of the current user.
        public void RemoveFromCarts(ProductModel product, UserModel user, int count = 1)
        {
            if (user != null)
            {
                string fileName = Path.Combine(FILE_PATH, $"{user.Id}_cart.csv");

                List<ProductModel> cartProducts = GetAllProducts(user);

                int productId = -1;

                for (int i = 0; i < cartProducts.Count; i++)
                {
                    if (cartProducts[i].Id == product.Id)
                    {
                        productId = i;
                    }
                }

                if (productId != -1)
                {
                    ProductModel productToChange = cartProducts[productId];
                    productToChange.Quantity -= count;

                    if (productToChange.Quantity <= 0) 
                    {
                        cartProducts.Remove(productToChange);
                    }

                    using (var sw = new StreamWriter(fileName))
                    {
                        
                        foreach (ProductModel? p in cartProducts)
                        {
                            sw.WriteLine($"{p.Id},{p.Quantity}");
                        }
                    }
                }
            }
        }

        // This function gets all products in the cart of the current user.
        public List<ProductModel> GetAllProducts()
        {
            // Need to count the quantity of items that have the same id
            
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
                        ProductModel? product = productStorageService.GetProductById(int.Parse(parts[0]));
                        product!.Quantity = int.Parse(parts[1]);
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        // This function gets all products in the cart of a user with a given ID.
        public List<ProductModel> GetAllProducts(UserModel user)
        {
            // Need to count the quantity of items that have the same id
            
            List<ProductModel> products = new List<ProductModel>();

             string fileName = Path.Combine(FILE_PATH, $"{user.Id ?? 0}_cart.csv");

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        ProductModel? product = productStorageService.GetProductById(int.Parse(parts[0]));
                        product!.Quantity = int.Parse(parts[1]);
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }
}
