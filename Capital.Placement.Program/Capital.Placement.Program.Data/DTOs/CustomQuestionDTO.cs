using AutoMapper;

using Capital.Placement.Program.Data.Model;

namespace Capital.Placement.Program.Data.DTOs
{
    public class CustomQuestionDTO
    {
        public QuestionType Type { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }

    public class CustomQuestionAutoMapper : Profile
    {
        public CustomQuestionAutoMapper()
        {
            CreateMap<CustomQuestion, CustomQuestionDTO>().ReverseMap();
        }
    }
}
