using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Capital.Placement.Program.Data.Model
{
    public class PersonalInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string QuestionType { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }
    }
}
