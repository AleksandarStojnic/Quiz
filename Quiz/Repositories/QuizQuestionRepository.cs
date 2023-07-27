using Quiz.Context;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Quiz.Repositories
{
    public class QuizQuestionRepository : Repository<QuizQuestion>, IQuizQuestionRepository
    {
        public QuizQuestionRepository(DatabaseContext dbContext) : base(dbContext) { }

        public async Task<bool> DeleteQuizQuestions(List<QuizQuestion> entity)
        {
            table.RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}