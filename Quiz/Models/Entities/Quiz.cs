using System.Collections.Generic;

namespace Quiz.Models.Entities
{
    public class Quiz : EntityBase
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}