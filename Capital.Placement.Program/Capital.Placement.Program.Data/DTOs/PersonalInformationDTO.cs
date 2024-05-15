using AutoMapper;

using Capital.Placement.Program.Data.Model;

namespace Capital.Placement.Program.Data.DTOs
{
    public class PersonalInformationDTO
    {
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string QuestionType { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }
    }

    public class PersonalInformationMapper : Profile
    {
        public PersonalInformationMapper()
        {
            CreateMap<PersonalInformation, PersonalInformationDTO>().ReverseMap();
        }
    }
}
