using Quiz.Models.Entities;
using Quiz.Models.Responses;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<IEnumerable<Question>> SearchQuestions(string searchValue);

    }
}
