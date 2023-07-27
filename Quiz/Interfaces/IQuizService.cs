using Quiz.Models.Entities;
using Quiz.Models.Requests;
using Quiz.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interfaces
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizNakedResponse>> GetAllQuizes();
        Task<bool> CreateQuiz(CreateQuizRequest request);
        Task<IEnumerable<QuestionResponse>> SearchQuestions(string searchValue);
        Task<QuizResponse> GetQuizById(int id);
        Task<bool> UpdateQuiz(QuizResponse request);
        Task<bool> DeleteQuiz(int quizId);
    }
}
