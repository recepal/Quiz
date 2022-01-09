using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Model
{
    [Table("exams")]
    public class Exam : EntityBase
    {
        public string Header { get; set; }
        public DateTime Date { get; set; }
    }
}
