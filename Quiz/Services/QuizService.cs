using Quiz.Interfaces;
using Quiz.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Quiz.Models.Entities.Quizz> _quizRepository;

        public QuizService(IRepository<Question> questionRepository, IRepository<Models.Entities.Quizz> quizRepository)
        {
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
        }

        public async Task<IEnumerable<Quizz>> GetAllQuizes()
        {
            //For performance sake it would better to implement repository for both quiz and question 
            //And then inside quiz repository make method that does not return questions at all

            var result = await _quizRepository.GetAll();

            foreach(var item in result)
            {
                item.Questions = null;
            }

            return result;
        }
    }
}