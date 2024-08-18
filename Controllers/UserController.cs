using CastingWebAPI.Dtos;
using CastingWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastingWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) { 
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> SignUp([FromBody] CreateUserDto request)
        {
            try
            {
                var user = await userService.SignUpAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                var user = await userService.LoginAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnauthorizedAccessException))
                    return Unauthorized("Invalid Password");
                return BadRequest(ex.Message);
            }
        }
    }
}
