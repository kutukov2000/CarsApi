namespace DataAccess.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Prompt { get; set; }
        public int SurveyId { get; set; }
    }
}
