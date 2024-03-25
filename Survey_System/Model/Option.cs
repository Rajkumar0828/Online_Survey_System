namespace Survey_System.Model
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Text { get; set; }



        public Question Question { get; set; }
        //public int QuestionId { get; set; }
    }
}
