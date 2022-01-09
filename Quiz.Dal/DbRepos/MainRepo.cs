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

        public void AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Exam> GetExam(Guid examId)
        {
            return await _context.Exams.FirstOrDefaultAsync(f => f.Id == examId);
        }

        public void UpdateExam(Exam exam)
        {
            _context.Attach(exam);
            _context.Entry(exam).State = EntityState.Modified;
        }

        public async Task<List<Exam>> GetExams()
        {
            return await _context.Exams.Where(f => !f.IsDeleted).ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByExamId(Guid examId)
        {
            return await _context.Questions.Where(f => !f.IsDeleted && f.ExamId == examId).ToListAsync();
        }

        public async Task<List<Answer>> GetAnswersByQuestionId(Guid questionId)
        {
            return await _context.Answers.Where(f => !f.IsDeleted && f.QuestionId == questionId).ToListAsync();
        }
    }
}
