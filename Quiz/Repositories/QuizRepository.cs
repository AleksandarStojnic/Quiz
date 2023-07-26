using Quiz.Context;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Quiz.Repositories
{
    public class QuizRepository : Repository<Quizz> ,IQuizRepository
    {
        public QuizRepository(DatabaseContext dbContext) : base(dbContext) { }

    }
}