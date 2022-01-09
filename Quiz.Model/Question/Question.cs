using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Model
{
    [Table("questions")]
    public class Question : EntityBase
    {
        public Guid ExamId { get; set; }
        public string Description { get; set; }
    }
}
