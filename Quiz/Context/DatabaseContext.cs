using Quiz.Models.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Quiz.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection") 
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 300;
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Models.Entities.Quizz> Quizes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

    }
}