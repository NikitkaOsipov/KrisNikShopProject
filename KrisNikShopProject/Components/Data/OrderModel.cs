namespace KrisNikShopProject.Components.Data
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public double Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public string? CardNumber {get; set;}
        public string? NameSurName {get; set;}
        public int? ArrivelTime { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(int id, string name, string description, double price, int quantity, string category, string brand, string size, string material, string country, int arrivelTime, string image)
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
            Country = country;
            ArrivelTime = arrivelTime;
        }

        public OrderModel(ProductModel product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
            Category = product.Category;
            Brand = product.Brand;
            Size = product.Size;
            Material = product.Material;
            Image = product.Image;
            Country = product.Country;
            CardNumber = "2143133535345";
            NameSurName = "Kris sapog";
            ArrivelTime = 12;
        }

        public override string ToString()
        {
            return Id + "," + Name + "," + Description + "," + Price + "," + Image + "," + Quantity + "," + Category + "," + Brand + "," + Size + "," + Material;
        }
    
    }
}
