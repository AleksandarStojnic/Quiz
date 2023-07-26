using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models.Responses
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}