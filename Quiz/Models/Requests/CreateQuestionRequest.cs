using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models.Requests
{
    public class CreateQuestionRequest
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}