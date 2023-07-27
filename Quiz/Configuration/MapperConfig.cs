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
                cfg.CreateMap<Question, QuestionResponse>()
                .ReverseMap();
                cfg.CreateMap<Quizz, QuizResponse>()
                .ReverseMap();
                cfg.CreateMap<QuestionResponse, QuizQuestion>()
                .ForMember(x => x.QuestionId, src => src.MapFrom(y => y.Id))
                .ForPath(x => x.Question.QuestionText, src => src.MapFrom(y => y.QuestionText))
                .ForPath(x => x.Question.Answer, src => src.MapFrom(y => y.Answer));
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}