using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Server.Service;
using Server.Models.ApiRequest;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UsersService m_userService;

        public AccountController(UsersService usersService)
        {
            m_userService = usersService;
        }

        //[NonAction]

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(Login user)
        {
            var data = await m_userService.GetByEmail(user.Email);
            if (data == null) { return BadRequest("email or pass not correct"); }
            if (!data.Pwd.Equals(user.Pwd))
            {
                return BadRequest("email or pass not correct");
            }
            //var obj = db.Users.Where(a => a.UserName.Equals(u.UserName) && a.UserPassword.Equals(u.UserPassword)).FirstOrDefault();
            //if (obj != null)
            //{
            HttpContext.Session.SetInt32("CurrentUser", data.Id);
            return Ok(HttpContext.Session.GetInt32("CurrentUser"));
        }

        //[NonAction]
        [HttpPost("[action]")]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.Session.Remove("CurrentUser");

            return Ok();
        }
    }
}
