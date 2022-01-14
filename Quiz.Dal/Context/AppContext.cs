using Microsoft.EntityFrameworkCore;
using Npgsql;
using Quiz.Model;

namespace Quiz.Dal
{
    public partial class AppContext : DbContext
    {
        private readonly string _connectionStr = "User ID=abcde; Password=adan; Host=localhost; Port=5542; Database=QuizDb; Pooling=false; Timeout=300; CommandTimeout=180;";

        //dotnet-ef migrations add Initials --startup-project ..\Quiz.Service  // yan çizgiye dikkat et

        public AppContext()
        {

        }

        public AppContext(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStr); // postre bağlantısı
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelTypes = modelBuilder.Model.GetEntityTypes();

            foreach (var modelType in modelTypes) //counter
            {

                if (modelType.ClrType == typeof(EntityBase))
                {
                    modelBuilder.Entity(modelType.Name)
                        .Property("Counter")
                        .ValueGeneratedOnAdd();
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
