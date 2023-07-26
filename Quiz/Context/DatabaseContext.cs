using Quiz.Models.Entities;
using System.Data.Entity;

namespace Quiz.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection") { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Models.Entities.Quiz> Quizes { get; set; }

    }
}