namespace Quiz.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Counter { get; set; }
        public string Description { get; set; }
    }
}