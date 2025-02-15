﻿namespace KrisNikShopProject.Components.Data
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
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
        public string? CardNumber { get; set; }
        public string? NameSurName { get; set; }
        public TimeSpan TravelTime { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfArrival { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(int id, int productID, string name, string description, double price, int quantity, ProductCategories category, string brand, string size, string material, string country, TimeSpan travelTime, DateTime dateOfArrival, DateTime dateofOrder, string image)
        {
            Id = id;
            ProductID = productID;
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
            TravelTime = travelTime;
            DateOfOrder = dateofOrder;
            DateOfArrival = dateOfArrival;
        }

        public OrderModel(ProductModel product, UserModel user)
        {
            ProductID = product.Id;
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
            CardNumber = user.CardNumber;
            NameSurName = user.CardNameSurname;
            TravelTime = product.TravelTime;
            DateOfOrder = DateTime.Now;
            DateOfArrival = DateOfOrder.Add(TravelTime);
        }
    }
}
