﻿namespace Quiz.Models.Entities
{
    public class Question : EntityBase
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}