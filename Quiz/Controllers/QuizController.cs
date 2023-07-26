using System.Web.Http;

namespace Quiz.Controllers
{
    [Route("quiz/[controller]")]
    public class QuizController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public string GetTest()
        {
                return "test";
        }
    }
}
