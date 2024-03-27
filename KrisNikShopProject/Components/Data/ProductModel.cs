namespace KrisNikShopProject.Components.Data
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Image { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int id, string name, string description, double price, int quantity, string category, string brand, string size, string material, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
            Brand = brand;
            Size = size;
            Material = material;
            Image = image;
        }

        public override string ToString()
        {
            return Id + "," + Name + "," + Description + "," + Price + "," + Image + "," + Quantity + "," + Category + "," + Brand + "," + Size + "," + Material;
        }
    }
}
