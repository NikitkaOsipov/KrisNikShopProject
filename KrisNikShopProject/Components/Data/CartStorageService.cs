namespace KrisNikShopProject.Components.Data
{
    public class CartStorageService
    {
        private readonly UserRegistrationService userRegistrationService;

        public CartStorageService(UserRegistrationService userRegistrationService)
        {
            this.userRegistrationService = userRegistrationService;
            //In this code, the CartStorageService constructor takes a UserRegistrationService parameter,
            //which is provided by the dependency injection system. The parameter is assigned to the _userRegistrationService field,
            //which can then be used throughout the CartStorageService class.
        }

        public void AddProduct(ProductModel product, int count = 1)
        {
            if (userRegistrationService.CurrentUser != null)
            {
                string fileName = $"C:\\Users\\osipo\\BlazorProjects\\KrisNikShopProject\\KrisNikShopProject\\Components\\Collections\\UsersCarts\\{userRegistrationService.CurrentUser.Id}_cart.csv";

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
    }
}
