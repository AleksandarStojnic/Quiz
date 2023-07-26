using AutoMapper;
using Quiz.Configuration;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using Quiz.Models.Requests;
using Quiz.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizService(IRepository<Question> questionRepository, IQuizRepository quizRepository)
        {
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
            _mapper = MapperConfig.InitializeAutomapper();
        }

        public async Task<IEnumerable<QuizNakedResponse>> GetAllQuizes()
        {
            //For performance sake it would better to implement repository for both quiz and question 
            //And then inside quiz repository make method that does not return questions at all
            var result = await _quizRepository.GetAll();

            //Never return domain object. And automapper will help us so we dont have to type everything up by hand
            return _mapper.Map<IEnumerable<QuizNakedResponse>>(result);
        }

        public async Task<bool> CreateQuiz(CreateQuizRequest request)
        {
            try
            {
                List<Question> quizQuestions = new List<Question>();
                if (request.RecycledQuestions.Count > 0)
                {
                    
                    foreach (var item in request.RecycledQuestions)
                    {
                        quizQuestions.Add(await _questionRepository.GetById(item));
                    }
                }

                var quiz = _mapper.Map<Quizz>(request);

                foreach (var item in request.NewQuestions)
                {
                    quiz.Questions.Add(new QuizQuestion() { Question = _mapper.Map<Question>(item)});
                }

                foreach (var item in quizQuestions)
                {
                    quiz.Questions.Add(new QuizQuestion() { Question = _mapper.Map<Question>(item) });
                }

                _quizRepository.Create(quiz);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}