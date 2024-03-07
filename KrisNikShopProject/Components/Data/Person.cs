namespace KrisNikShopProject.Components
{
    public class Person
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Gender: {Gender}, Country: {Country}";
        }
    }
}
