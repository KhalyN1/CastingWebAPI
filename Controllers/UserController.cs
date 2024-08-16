using CastingWebAPI.Dtos;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CastingWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordService passwordService;
       
        public UserController(IUserRepository userRepository, IPasswordService passwordService)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
     
        }


        [HttpGet]
        public async Task<ActionResult> GetUsers() {
            var users = await userRepository.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("recruiters")]
        public async Task<ActionResult> GetRecruiters()
        {
            var recruiters = await userRepository.GetAllRecruitersAsync();

            return Ok(recruiters);
        }

        [HttpGet("actors")]
        public async Task<ActionResult> GetActors()
        {
            var actors = await userRepository.GetAllActorsAsync();

            return Ok(actors);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            
            if (user is null) 
                return NotFound();

            return Ok(user);
        }

        [HttpGet("recruiters/{id}")]
        public async Task<ActionResult<UserDto>> GetRecruiter(Guid id)
        {
            var recruiter = await userRepository.GetRecruiterByIdAsync(id);

            if (recruiter is null)
                return NotFound();

            return Ok(recruiter);
        }

        [HttpGet("actors/{id}")]
        public async Task<ActionResult> GetActor(Guid id)
        {
            var actor = await userRepository.GetActorByIdAsync(id);

            if (actor is null)
                return NotFound();

            return Ok(actor);
        }

        [HttpGet("recruiters/{recruiterId}/projects")] 
         public async Task<ActionResult> GetProjectsByRecruiterId(Guid recruiterId)
        {
            var user = await userRepository.GetRecruiterByIdAsync(recruiterId);

            if (user is null)
                return NotFound();

            if (user is not Recruiter)
                return BadRequest("This user is not a recruiter");

            return Ok(user.Projects);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser([FromBody] UserSignUpForm form)
        {
            if (ModelState.IsValid) {

                if (userRepository.ExistsByUsername(form.Username).Result) {

                    return BadRequest("Username is already taken");
                }

                if (userRepository.ExistsByEmail(form.Email).Result) {

                    return BadRequest("That email address is already in use");
                }
                User newUser;
                if (form.userType == "Actor")
                {
                    newUser = new Actor()
                    {
                        Username = form.Username,
                        Email = form.Email,
                        PasswordHash = passwordService.HashPassword(form.Password, out byte[] salt),
                        salt = salt,
                        birthDate = form.birthDate,
                        personalInfo = null
                    };
                }
                else if (form.userType == "Recruiter")
                {
                    newUser = new Recruiter()
                    {
                        Username = form.Username,
                        Email = form.Email,
                        PasswordHash = passwordService.HashPassword(form.Password, out byte[] salt),
                        salt = salt,
                        birthDate = form.birthDate,
                    };
                }
                else return BadRequest("Incorrect user type");

                try
                {
                    await userRepository.AddUserAsync(newUser);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(newUser);

            }

            return BadRequest(ModelState);

        }

        /* updating will be added a bit later
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
        {
            try
            {
                await userRepository.DeleteUserByIdAsync(id);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

            return Ok("Deleted user with id " + id);
            
        }
        
    }
}
