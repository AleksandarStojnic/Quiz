using Quiz.Models;
using Quiz.Models.Entities;
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
            var questions = SeedQuestions();

            context.Quizes.AddRange(quizes);
            context.Questions.AddRange(questions);
            context.SaveChanges();

            //Would be better to use some sort of condition instead of hardcodedIds but its just seed for testing not to be used in production
            context.QuizQuestions.Add(new QuizQuestion { QuestionId = 1, QuizzId = 1 });
            context.QuizQuestions.Add(new QuizQuestion { QuestionId = 1, QuizzId = 1 });
            context.QuizQuestions.Add(new QuizQuestion { QuestionId = 3, QuizzId = 2 });
            context.QuizQuestions.Add(new QuizQuestion { QuestionId = 4, QuizzId = 2 });
            context.SaveChanges();

        }

        private List<Question> SeedQuestions ()
        {
            List<Question> result = new List<Question>();
            result.Add(
                    new Models.Entities.Question
                    {
                        QuestionText = "What is a Data Structure?",
                        Answer = "A data structure is a storage format that defines the way data is stored, organized, and manipulated."
                    });
            result.Add(
                    new Models.Entities.Question
                    {
                        QuestionText = "What is an Array?",
                        Answer = "An array is commonly referred to as a collection of items stored at contiguous memory locations."
                    });
            result.Add(
                   new Models.Entities.Question
                   {
                       QuestionText = " In which state can you find the Grand Canyon?",
                       Answer = "Arizona"
                   });
            result.Add(
                   new Models.Entities.Question
                   {
                       QuestionText = "Which country is made up of 7,000 islands?",
                       Answer = "The Philippines"
                   });

            return result;
        }

        private List<Quiz.Models.Entities.Quizz> SeedQuizes()
        {
            List<Quiz.Models.Entities.Quizz> quizzes = new List<Models.Entities.Quizz>();

            quizzes.Add(new Models.Entities.Quizz
            {
                Name = "Data Structures",
            });

            quizzes.Add(new Models.Entities.Quizz
            {
                Name = "Geography",
            });

            return quizzes;
        }
    }
}