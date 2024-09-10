using Bootcamp.Data.Interface;
using Bootcamp.Data.Models.Auth;
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
    }
}
