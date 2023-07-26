using Quiz.Context;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Repositories
{
    public class QuizRepository : Repository<Quizz> ,IQuizRepository
    {
        public QuizRepository(DatabaseContext dbContext) : base(dbContext) { }

        public async Task<Quizz> GetQuizById(int id)
        {
            //Since we are forced to use .NET Framework instead of .NET core we cannot use .ThenInclude so we will have to get questions by hand;
            return await table.Where(x => x.Id == id).Include(x => x.Questions).FirstOrDefaultAsync();
        }
    }
}