using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Survey_System.Data;
using Survey_System.Model;
using Google.Protobuf;

namespace Survey_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SignupController(AppDbContext Context)
        {
            _context = Context;

        }

        [HttpPost]
        public IActionResult PostUser(SignupDto user)
        {
            SurveyUser user1 = new SurveyUser()
            {
                
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                Password = user.Password,

            };

            if (_context.Users.Any(user => user.UserEmail == user1.UserEmail))
            {
                return Ok();

            }

            _context.Users.Add(user1);

            if (_context.SaveChanges() > 0)
            {
                SurveyUser resuser = _context.Users.FirstOrDefault(user => user.UserName == user1.UserName)!;

                return BadRequest("Internal Server Error ! please try again later");
            }

            return Ok();

        }

    }
}
