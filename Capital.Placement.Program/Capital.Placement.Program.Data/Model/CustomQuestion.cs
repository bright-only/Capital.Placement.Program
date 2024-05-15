

namespace Capital.Placement.Program.Data.Model
{
    public class CustomQuestion
    {
        public string Type { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }

    public enum QuestionType
    {
        Paragraph = 0,
        Date = 1,
        YesNo = 2,
        Dropdown = 3,
        Number = 4
    }

    //public class DropdownQuestion : CustomQuestion
    //{
    //    public bool EnableOtherOption { get; set; }
    //    public List<Choice> Choices { get; set; }

    //    public DropdownQuestion()
    //    {
    //        Choices = new List<Choice>();
    //    }
    //}

    //public class Choice
    //{
    //    public string Text { get; set; }
    //}
}
