using AutoMapper;

using Capital.Placement.Program.Data.Model;
using Capital.Placement.Program.Data.Validation;

namespace Capital.Placement.Program.Data.DTOs
{
    public class UpdatePersonalInformationRequestDTO : GenericPersonalInformation
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }
    }

    public class UpdatePersonalInformationRequestMapper : Profile
    {
        public UpdatePersonalInformationRequestMapper()
        {
            CreateMap<PersonalInformation, UpdatePersonalInformationRequestDTO>().ReverseMap();
        }
    }
}
