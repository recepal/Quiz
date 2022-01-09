using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Model
{
    [Table("answers")]
    public class Answer : EntityBase
    {
        public Guid QuestionId { get; set; }
        public string AnswerName { get; set; }
        public bool IsCorrect { get; set; }
    }
}
