using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dal
{
    public interface IMainRepo
    {
        bool CreateDb();
        void AddQuestions(List<Question> questions);
        void AddAnswers(List<Answer> answers);
    }
}
