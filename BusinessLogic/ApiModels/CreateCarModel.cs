namespace Core.ApiModels
{
    public class CreateCarModel
    {
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
    }
}
