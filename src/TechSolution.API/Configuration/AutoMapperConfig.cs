using AutoMapper;
using TechSolution.API.ViewModels;
using TechSolution.Business.Models;

namespace TechSolution.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
            CreateMap<AnswerComment, AnswerCommentViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<QuestionComment, QuestionCommentViewModel>().ReverseMap();
        }
    }
}
