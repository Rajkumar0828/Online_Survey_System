using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_System.Model
{
    public class Response
    {
        public int  ResponseId { get; set; }


        //public string Answer { get; set; }
        
        public List<string> Answers { get; set; }

        

        public DateTime? SubmittedAt { get; set; }

       
        
        public Survey surveys { get; set; }
        public Question Questions { get; set; }
        


        public SurveyUser Users { get; set; }

        


    }
}
