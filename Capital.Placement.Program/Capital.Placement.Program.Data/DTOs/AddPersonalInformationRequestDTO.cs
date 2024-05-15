using AutoMapper;

using Capital.Placement.Program.Data.Model;
using Capital.Placement.Program.Data.Validation;

namespace Capital.Placement.Program.Data.DTOs
{
    public class AddPersonalInformationRequestDTO : GenericPersonalInformation
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }
    }

    public class AddPersonalInformationRequestMapper : Profile
    {
        public AddPersonalInformationRequestMapper()
        {
            CreateMap<PersonalInformation, AddPersonalInformationRequestDTO>().ReverseMap();
        }
    }
}
