using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Quiz.Models.Requests
{
    public class CreateQuizRequest
    {
        public string Name { get; set; }

        public List<CreateQuestionRequest> NewQuestions { get; set; }

        public List<int> RecycledQuestions { get; set; }
    }
}