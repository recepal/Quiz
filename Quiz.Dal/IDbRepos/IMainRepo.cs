using Quiz.Model;

namespace Quiz.Dal
{
    public interface IMainRepo
    {
        bool CreateDb();
        void AddQuestions(List<Question> questions);
        void AddAnswers(List<Answer> answers);
        void AddExam(Exam exam);
        Task<Exam> GetExam(Guid examId);
        void UpdateExam(Exam exam);
        Task<List<Exam>> GetExams();
        Task<List<Question>> GetQuestionsByExamId(Guid examId);
        Task<List<Answer>> GetAnswersByQuestionId(Guid questionId);
        Task<bool> SaveAsync();
    }
}
