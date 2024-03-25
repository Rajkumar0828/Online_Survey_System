namespace Survey_System.Model
{
    public class Survey 
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public DateTime CreatedAt { get; set; }

        
        public List<Response> Responses { get;  }
        public List<Question> Questions { get;  }

        
    }
}
