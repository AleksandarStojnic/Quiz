
using Quiz.Context;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using Quiz.Models.Responses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.UI.WebControls.Expressions;

namespace Quiz.Repositories
{
    public class QuestionRepository : Repository<Question> ,IQuestionRepository
    {
        public QuestionRepository(DatabaseContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Question>> SearchQuestions(string searchValue)
        {
            //It would be better to have dedicated extension methods that are generic and can be used on any table for sorting and filtering but since we only
            //need to implement search on one table I did it like this since its quicker for me 
            //It wasnt specified if searchValue should be case insensitive but if it should be 
            //Then change code below with this line
            // return await table.Where(x => x.Answer.Contains(searchValue, StringComparison.OrdinalIgnoreCase) || x.QuestionText.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            return await table.Where(x => x.Answer.Contains(searchValue) || x.QuestionText.Contains(searchValue)).ToListAsync();
        }

    }
}