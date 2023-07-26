using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var quizes = SeedQuizes();

            context.Quizes.AddRange(quizes);
            context.SaveChanges();
        }

        private List<Quiz.Models.Entities.Quizz> SeedQuizes()
        {
            List<Quiz.Models.Entities.Quizz> quizzes = new List<Models.Entities.Quizz>();

            quizzes.Add(new Models.Entities.Quizz
            {
                Name = "Data Structures",
                Questions = new List<Models.Entities.Question>
                {
                    new Models.Entities.Question
                    {
                        QuestionText = "What is a Data Structure?",
                        Answer="A data structure is a storage format that defines the way data is stored, organized, and manipulated."
                    },
                    new Models.Entities.Question
                    {
                        QuestionText = "What is an Array?",
                        Answer = "An array is commonly referred to as a collection of items stored at contiguous memory locations."
                    }
                }
            });

            quizzes.Add(new Models.Entities.Quizz
            {
                Name = "Geography",
                Questions = new List<Models.Entities.Question>
                {
                    new Models.Entities.Question
                    {
                        QuestionText = " In which state can you find the Grand Canyon?",
                        Answer="Arizona"
                    },
                    new Models.Entities.Question
                    {
                        QuestionText = "Which country is made up of 7,000 islands?",
                        Answer = "The Philippines"
                    }
                }
            });

            return quizzes;
        }
    }
}