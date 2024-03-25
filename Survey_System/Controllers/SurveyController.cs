using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey_System.Data;
using Survey_System.Model;

using Microsoft.EntityFrameworkCore;

namespace Survey_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly AppDbContext _surveys;

        public SurveyController(AppDbContext surveys)
        {
            _surveys = surveys;
        }



        [HttpPost]
        public async Task<ActionResult<Survey>> AddSurvey(SurveyDto survey)
        {
            Survey survey1 = new Survey()
            {
                SurveyId = 0,
                Title = survey.Title,
                Description = survey.Description,
                CreatedAt = DateTime.Now
            };

            _surveys.Add(survey1);
            await _surveys.SaveChangesAsync();

            return Ok(survey);
        }

        [HttpPost("AddQuestions")]
        public ActionResult AddQuestionsToSurvey([FromBody] AddQuestionDto addQuestionsDto)
        {
            // Find the survey using the ID from the DTO
            Survey survey = _surveys.Surveys.Find(addQuestionsDto.SurveyId);
            if (survey == null)
            {
                return NotFound("Survey not found");
            }

            // Loop through each questionDto in the Questions list
            foreach (var questionDto in addQuestionsDto.Questions)
            {
                // Create a new question for each text in the Texts list
                foreach (var text in questionDto.Texts)
                {
                    Question question = new Question()
                    {
                        QuestionId = 0,
                        Text = text,
                        surveys = survey
                    };

                    // Add the question to the Questions table
                    _surveys.Questions.Add(question);
                }
            }

            // Save changes to the database
            _surveys.SaveChanges();

            // Loop through each questionDto in the Questions list again to add options
            foreach (var questionDto in addQuestionsDto.Questions)
            {
                // Find the question using the text
                Question question = _surveys.Questions.FirstOrDefault(q => q.Text == questionDto.Texts[0] && q.surveys == survey);

                // Create a new option for each optionText in the Options list
                foreach (var optionText in questionDto.Options)
                {
                    Option option = new Option()
                    {
                        Text = optionText,
                        OptionId = 0,
                        Question = question
                    };

                    // Add the option to the Options table
                    _surveys.Options.Add(option);
                }
            }

            // Save changes to the database
            _surveys.SaveChanges();

            return Ok();
        }


        [HttpGet("{id}")]
        public ActionResult GetSurvey(int id)
        {
            var survey = _surveys.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefault(s => s.SurveyId == id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }
        [HttpGet]
        public ActionResult GetSurveys()
        {
            var surveys = _surveys.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Options)
                .ToList();

            if (surveys == null || !surveys.Any())
            {
                return NotFound();
            }

            return Ok(surveys);
        }




        [HttpPut("UpdateQuestion")]
        public ActionResult UpdateQuestionInSurvey([FromBody] UpdateQuestionDto updateQuestionDto)
        {
            // Find the survey using the ID from the DTO
            Survey survey = _surveys.Surveys.Find(updateQuestionDto.SurveyId);
            if (survey == null)
            {
                return NotFound("Survey not found");
            }

            // Find the question using the ID
            Question question = _surveys.Questions.FirstOrDefault(q => q.QuestionId == updateQuestionDto.QuestionId && q.surveys == survey);

            if (question != null)
            {
                // Update the question text
                question.Text = updateQuestionDto.NewQuestionText;

                // Check if the question has options before trying to remove them
                if (question.Options != null)
                {
                    _surveys.Options.RemoveRange(question.Options);
                    question.Options.Clear(); // Clear the options list
                }

                // Create a new option for each optionText in the NewOptions list
                foreach (var optionText in updateQuestionDto.NewOptions)
                {
                    Option option = new Option()
                    {
                        Text = optionText,
                        OptionId = 0,
                        Question = question
                    };

                    // Add the option to the Options table
                    _surveys.Options.Add(option);
                }

                // Save changes to the database
                _surveys.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound("Question not found");
            }
        }


        [HttpDelete("DeleteQuestion")]
        public ActionResult DeleteQuestionInSurvey([FromBody] DeleteQuestionDto deleteQuestionDto)
        {
            // Find the survey using the ID from the DTO
            Survey survey = _surveys.Surveys.Find(deleteQuestionDto.SurveyId);
            if (survey == null)
            {
                return NotFound("Survey not found");
            }

            // Find the question using the ID
            Question question = _surveys.Questions.FirstOrDefault(q => q.QuestionId == deleteQuestionDto.QuestionId && q.surveys == survey);

            if (question != null)
            {
                // Check if the question has options before trying to remove them
                if (question.Options != null)
                {
                    _surveys.Options.RemoveRange(question.Options);
                }

                // Remove the question
                _surveys.Questions.Remove(question);

                // Save changes to the database
                _surveys.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound("Question not found");
            }
        }


        [HttpPost("AddResponses")]
        public ActionResult AddResponsesToQuestions([FromBody] AddResponseDto addResponseDto)
        {
            // Find the survey, question, and user using the IDs from the DTO
            Survey survey = _surveys.Surveys.Find(addResponseDto.SurveyId);
            Question question = _surveys.Questions.Find(addResponseDto.QuestionId);
            SurveyUser user = _surveys.Users.Find(addResponseDto.UserId);

            if (survey == null || question == null || user == null)
            {
                return NotFound("Survey, question, or user not found");
            }

            // Create a new response
            Response response = new Response()
            {
                ResponseId = 0,
                SubmittedAt = DateTime.Now,
                surveys = survey,
                Questions = question,
                Users = user,
                Answers = addResponseDto.Answers
            };

            // Log the response details
            Console.WriteLine($"Response Details: \nResponseId: {response.ResponseId}, \nSubmittedAt: {response.SubmittedAt}, \nSurveyId: {response.surveys.SurveyId}, \nQuestionId: {response.Questions.QuestionId}, \nUserId: {response.Users.SurveyUserID}, \nAnswers: {string.Join(", ", response.Answers)}");

            // Add the response to the Responses table
            _surveys.Responses.Add(response);

            // Save changes to the database
            _surveys.SaveChanges();

            return Ok();
        }






        //[HttpPost("AddQuestion")]

        //public ActionResult AddQuestionToSurvey([FromBody] AddQuestionDto addQuestionDto)
        //{
        //    Survey survey = _surveys.Surveys.Find(addQuestionDto.SurveyId)!;
        //    Question question = new Question()
        //    {
        //        QuestionId=0,
        //        Text = addQuestionDto.Question,
        //        surveys= survey

        //    };
        //    _surveys.Questions.Add(question);
        //    _surveys.SaveChanges();
        //    for (int i = 0; i < addQuestionDto.Options.Count; i++)
        //    {
        //        Option option = new Option()
        //        {
        //            Text= addQuestionDto.Options[i],
        //            OptionId=0,
        //            Question= question

        //        };
        //        _surveys.Options.Add(option);
        //        _surveys.SaveChanges();

        //    }





        //    return Ok();
        //}
        //[HttpPost]
        //public IActionResult SurveysResponse()
        //{

        //}
    }
}
