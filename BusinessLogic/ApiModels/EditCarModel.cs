namespace BusinessLogic.ApiModels
{
    public class EditCarModel
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
    }
}
