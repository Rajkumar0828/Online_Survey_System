namespace Survey_System.Model
{
    public class Question
    {
        public int  QuestionId { get; set; }
        public string Text { get; set; }

        
        public List<Option> Options { get; }    

        public Survey surveys { get; set; }
       
        
    }

}
