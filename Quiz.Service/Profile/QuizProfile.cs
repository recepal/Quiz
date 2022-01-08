using AutoMapper;
using Quiz.Dtos;
using Quiz.Model;

namespace Quiz.Service
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<AnswerDto, Answer>().ReverseMap();
        }
    }
}
