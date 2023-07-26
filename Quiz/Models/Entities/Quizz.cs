using System.Collections.Generic;

namespace Quiz.Models.Entities
{
    public class Quizz : EntityBase
    {
        public string Name { get; set; }
        public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
    }
}