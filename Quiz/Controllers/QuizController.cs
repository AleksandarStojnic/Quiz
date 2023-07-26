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
    public class QuizController : ApiController
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [Route("getallquizes")]
        public async Task<IEnumerable<QuizNakedResponse>> GetAllQuizzesAsync()
        {
            var result = await _quizService.GetAllQuizes();

            return result;
        }

        [HttpPost]
        [Route("createquiz")]
        public async Task<bool> CreateQuiz([FromBody] CreateQuizRequest request)
        {
            var result = await _quizService.CreateQuiz(request);

            return result;
        }
    }
}
