using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models.Entities
{
    //We need this connection table since 1 question can be part of multiple quizes and every quiz can have multiple questions
    //And we made table by hand since if we left it to EF, EF can sometimes go crazy with m:n relationships
    public class QuizQuestion : EntityBase
    {
        public int QuizzId { get; set; }
        public Quizz Quizz { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}