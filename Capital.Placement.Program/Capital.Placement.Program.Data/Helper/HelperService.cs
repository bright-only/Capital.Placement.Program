using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Data.Model;

using System.Text.RegularExpressions;

namespace Capital.Placement.Program.Data.Helper
{
    public static class HelperService
    {
        public static List<CustomQuestion> MapCustomQuestions( List<CustomQuestion> customQuestion, AddPersonalInformationRequestDTO req )
        {
            if (customQuestion == null)
                return null;

            var customQuestions = new List<CustomQuestion>();
            foreach (var item in customQuestion)
            {
                var question = new CustomQuestion
                {
                    QuestionText = item.QuestionText,
                    Type = req.QuestionType.ToString(),
                    Answer = item.Answer
                };
                customQuestions.Add(question);
            }
            return customQuestions;
        }

        public static List<CustomQuestion> MapCustomQuestions( List<CustomQuestion> customQuestion, UpdatePersonalInformationRequestDTO req )
        {
            if (customQuestion == null)
                return null;

            var customQuestions = new List<CustomQuestion>();
            foreach (var item in customQuestion)
            {
                var question = new CustomQuestion
                {
                    QuestionText = item.QuestionText,
                    Type = req.QuestionType.ToString(),
                    Answer = item.Answer
                };
                customQuestions.Add(question);
            }
            return customQuestions;
        }

        public static bool ContainsSpecialCharacters( string value )
        {
            // Define a regular expression pattern to match special characters.
            string pattern = @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]";

            // Use Regex.IsMatch to check if the value contains special characters.
            return Regex.IsMatch(value, pattern);
        }

        public static bool BeAValidDate( DateTime? date )
        {
            return date.HasValue && date.Value.Date >= DateTime.Now.Date;
        }
    }
}
