using AutoMapper;
using Quiz.Models.Entities;
using Quiz.Models.Requests;
using Quiz.Models.Responses;
using System.Configuration;
using System.Linq;

namespace Quiz.Configuration
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quizz, QuizNakedResponse>();
                cfg.CreateMap<CreateQuestionRequest, Question>();
                cfg.CreateMap<CreateQuizRequest, Quizz>();
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}