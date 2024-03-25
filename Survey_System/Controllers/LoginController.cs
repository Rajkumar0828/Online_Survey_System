using Microsoft.AspNetCore.Mvc;
using Survey_System.Data;
using Survey_System.Model;
using System.Runtime.Intrinsics.X86;

namespace Survey_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext Context)
        {
            _context = Context;

        }

        [HttpPost]

        public IActionResult LoginUser([FromBody] LoginDto loginuser)
        {
            if (loginuser != null)
            {

                SurveyUser user1 = new SurveyUser()
                {


                    UserEmail = loginuser.UserEmail,
                    Password = loginuser.Password,
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
            return Ok();
        }
    }
    

}
