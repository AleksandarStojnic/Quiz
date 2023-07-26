using System.Collections.Generic;

namespace Quiz.Models.Entities
{
    public class Quizz : EntityBase
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}