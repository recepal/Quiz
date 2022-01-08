using Microsoft.EntityFrameworkCore;
using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dal
{
    public class MainRepo : IMainRepo
    {
        private readonly AppContext _context;

        public MainRepo()
        {
            _context = new AppContext();
        }

        public bool CreateDb()
        {
            bool result;
            try
            {
                _context.Database.Migrate();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public void AddQuestions(List<Question> questions)
        {
            _context.Questions.AddRange(questions);
        }

        public void AddAnswers(List<Answer> answers)
        {
            _context.Answers.AddRange(answers);
        }
    }
}
