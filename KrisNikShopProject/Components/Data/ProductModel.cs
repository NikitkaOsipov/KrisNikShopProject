namespace KrisNikShopProject.Components.Data
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public double Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductCategories? Category { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public TimeSpan TravelTime { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int id, string name, string description, double price, ProductCategories category, string brand, string size, string material, string country, string image, TimeSpan travelTime)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Brand = brand;
            Size = size;
            Material = material;
            Country = country;
            Image = image;
            TravelTime = travelTime;
        }
    }
}
 