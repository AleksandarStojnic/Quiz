using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models.Responses
{
    public class QuizResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //I put name here as TransformedQuestions insted of Questions even tho latter would be more correct since then I would have to lose time typing custom mapping in MapperConfig.cs
        //Since automapper mapps by name
        public List<QuestionResponse> TrasformedQuestions { get; set; } = new List<QuestionResponse>();
    }
}