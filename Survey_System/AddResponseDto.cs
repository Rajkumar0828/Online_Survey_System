using Survey_System.Model;

namespace Survey_System
{
    public class AddResponseDto
    {
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public int UserId { get; set; }
        
        public List<string> Answers { get; set; }
    }
}
