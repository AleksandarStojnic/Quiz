using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interfaces
{
    public interface IQuizQuestionRepository : IRepository<QuizQuestion>
    {
        Task<bool> DeleteQuizQuestions(List<QuizQuestion> entity);
    }
}
