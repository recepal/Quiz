namespace Quiz.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerName { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsDeleted { get; set; }
        public int Counter { get; set; }
    }
}
