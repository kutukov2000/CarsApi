namespace BusinessLogic.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
