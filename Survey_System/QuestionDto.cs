using Survey_System.Model;

namespace Survey_System
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public List<string> Texts { get; set; }
        public List<string> Options { get; set; }
        
        //public string Text { get; set; }

        //public int OptionId { get; set; }

       //public Question Question { get; set; }

    }
}
