using Quiz.Interfaces;
using Quiz.Models.Entities;
using Quiz.Models.Requests;
using Quiz.Models.Responses;
using Quiz.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Quiz.Controllers
{
    //Every endpoint is missing possible status codes and better return value (something more generic)
    public class QuizController : ApiController
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        /// <summary>
        /// Returns all quizes names and ids
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getallquizes")]
        public async Task<IEnumerable<QuizNakedResponse>> GetAllQuizzesAsync()
        {
            var result = await _quizService.GetAllQuizes();

            return result;
        }

        /// <summary>
        /// Create quiz command. Request template can be found in swagger
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createquiz")]
        public async Task<bool> CreateQuiz([FromBody] CreateQuizRequest request)
        {
            var result = await _quizService.CreateQuiz(request);

            return result;
        }

        /// <summary>
        /// Seaches questions based on some string value
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("searchquestions")]
        public async Task<IEnumerable<QuestionResponse>> SearchQuestions([FromUriAttribute] string searchValue)
        {
           return await _quizService.SearchQuestions(searchValue);
        }

        /// <summary>
        /// Fetches all information by id about one quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getsinglequiz")]
        public async Task<QuizResponse> GetQuizById([FromUriAttribute] int id)
        {
            return await _quizService.GetQuizById(id);
        }

        /// <summary>
        /// Updates quiz
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updatequiz")]
        public async Task<bool> UpdateQuiz([FromBody] QuizResponse request)
        {
            return await _quizService.UpdateQuiz(request);
        }

        /// <summary>
        /// Deletes quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletequiz")]
        public async Task<bool> DeleteQuiz([FromUriAttribute] int id)
        {
            return await _quizService.DeleteQuiz(id);
        }

    }
}
