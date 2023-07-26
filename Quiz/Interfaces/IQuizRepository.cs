using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interfaces
{
    public interface IQuizRepository : IRepository<Quizz>
    {
        Task<Quizz> GetQuizById(int id);
    }
}
