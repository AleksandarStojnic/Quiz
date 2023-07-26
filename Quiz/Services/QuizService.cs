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
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuestionRepository questionRepository, IQuizRepository quizRepository)
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
                var quiz = _mapper.Map<Quizz>(request);

                if (request.RecycledQuestions != null)
                {
                    
                    foreach (var item in request.RecycledQuestions)
                    {
                        quiz.Questions.Add(new QuizQuestion() 
                        {
                            Question = _mapper.Map<Question>(await _questionRepository.GetById(item)) 
                        });
                    }
                }

                foreach (var item in request.NewQuestions)
                {
                    quiz.Questions.Add(new QuizQuestion() { Question = _mapper.Map<Question>(item)});
                }

                _quizRepository.Create(quiz);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<QuestionResponse>> SearchQuestions(string searchValue)
        {
            return _mapper.Map<IEnumerable<QuestionResponse>>(await _questionRepository.SearchQuestions(searchValue));
        }

        public async Task<QuizResponse> GetQuizById(int id)
        {
            var quiz = await _quizRepository.GetQuizById(id);

            var response = _mapper.Map<QuizResponse>(quiz);

            //Since we are forced to use .NET Framework instead of .NET core we cannot use .ThenInclude so we will have to get questions by hand;
            foreach(var item in quiz.Questions)
            {
                //This is super bad practice. You should never have DB calls inside loop since it impacts performance. 
                //It would have been better if I took all questions from DB with 1 call and then filtered them, or If I filtered them at DB level but Im tired to write that in code
                response.TrasformedQuestions.Add(_mapper.Map<QuestionResponse>(await _questionRepository.GetById(item.QuestionId)));
            }

            return response;
        }
    }
}