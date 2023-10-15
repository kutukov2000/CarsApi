namespace DataAccess.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
