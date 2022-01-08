using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dtos
{
    public class QuestionAndAnswerPackDto
    {
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
