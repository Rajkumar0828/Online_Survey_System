namespace Survey_System.Model
{
    public class SurveyUser
    {
        public int SurveyUserID { get; set; }

        public string? UserName { get; set; }

         public string? UserEmail { get; set; }

        public string? Password { get; set; }

        public ICollection<Response> Responses { get; }


    }
}
