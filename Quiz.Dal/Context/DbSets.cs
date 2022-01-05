using Microsoft.EntityFrameworkCore;
using Quiz.Model;

namespace Quiz.Dal
{
    public partial class AppContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
