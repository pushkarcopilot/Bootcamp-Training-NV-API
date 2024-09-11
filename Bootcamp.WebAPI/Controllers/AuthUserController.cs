using Bootcamp.Data.Interface;
using Bootcamp.Data.Models;
using Bootcamp.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Bootcamp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthUser _authUser;
        public AuthUserController(IAuthUser authUser)
        {
            _authUser = authUser;
        }

        [HttpGet("GetLoginUserData/{UserName}")]

        public async Task<Users> GetLogInUserName([FromRoute] string UserName)
        {
            var userData = await _authUser.GetLogInUserName(UserName);

            if(userData == null)
            {
                return null;
            }
            return userData;
        }

        //[HttpGet("GetAuthUsers")]
        //public async Task<IActionResult> GetAuthUsers()
        //{
        //    Data.Models.AuthUser authUser = new()
        //    {
        //        UserNames = "tarun.jeengar@newvision-software.com,tushar.jeengar@newvision-software.com,divyansh.jain@newvision-software.com"
        //    };
        //    return Ok(authUser);
        //}


        [HttpGet("GetAuthUsers")]
        public async Task<IActionResult> GetAuthUsers()
        {
            List<Users> user = _authUser.GetAuthUsers();
            return Ok(user);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _authUser.AddData(user);

            return Ok(user);
        }
    }
}
