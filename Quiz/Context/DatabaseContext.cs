using Quiz.Models;
using System.Data.Entity;

namespace Quiz.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection") { }

        public DbSet<ToDo> ToDos { get; set; }

    }
}