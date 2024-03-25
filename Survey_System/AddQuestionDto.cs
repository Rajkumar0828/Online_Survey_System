using Survey_System.Model;
using Survey_System;
namespace Survey_System
{
    public class AddQuestionDto

    {
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public List<QuestionDto> Questions { get; set; }
        //public string Question {  get; set; }

        //public List<string> Options  { get; set; }
        //public int SurveyId { get; set; }

    }
}
