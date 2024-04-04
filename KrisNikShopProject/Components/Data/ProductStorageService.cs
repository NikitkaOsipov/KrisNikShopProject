namespace KrisNikShopProject.Components.Data
{
    public class ProductStorageService
    {
        private readonly string FILE_NAME;

        public ProductStorageService()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            FILE_NAME = Path.Combine(currentDirectory, Path.Combine("Components", "Collections", "Products.csv"));
        }
        
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            using (var reader = new StreamReader(FILE_NAME))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    ProductModel product = new ProductModel(
                                               int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]), int.Parse(parts[4]), 
                                               parts[5], parts[6], parts[7], parts[8], parts[9], int.Parse(parts[10] ?? "0"), parts[11]);
                    products.Add(product);
                }
            }

            return products;
        }

        public ProductModel? GetProductById(int id)
        {
            ProductModel? productID = null;
            List<ProductModel> products = GetAllProducts();
            foreach(ProductModel product in products)
            {
                if (id == product.Id)
                {
                    productID = product;
                }
            }
            return productID;
        }
    }
}
