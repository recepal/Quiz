using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dtos
{
    public class ExamPack
    {
        public Guid ExamId { get; set; }
        public string ExamHeader { get; set; }
        public DateTime ExamDate { get; set; }
        public List<QuestionAndAnswerPackDto> QuestionAndAnswers { get; set; }
    }

    public class QuestionAndAnswerPackDto
    {
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
