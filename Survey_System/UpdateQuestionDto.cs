namespace Survey_System
{
    
        public class UpdateQuestionDto
        {
            public int QuestionId { get; set; } // ID of the question being updated
           public int SurveyId { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public string NewQuestionText { get; set; } // Updated question text

            public List<string> NewOptions { get; set; } // List of updated option texts
        }

    
}
