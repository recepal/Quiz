using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Answer : EntityBase
    {
        public Guid QuestionId { get; set; }
        public string AnswerName { get; set; }
        public bool IsCorrect { get; set; }
    }
}
