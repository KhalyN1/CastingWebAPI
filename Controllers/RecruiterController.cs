using CastingWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CastingWebAPI.Models;
using CastingWebAPI.Repositories;
using CastingWebAPI.Extensions;
namespace CastingWebAPI.Controllers
{
    [Route("api/recruiters")]
    [ApiController]
    public class RecruiterController : Controller
    {
        private readonly IUserRepository<Recruiter> recruiterRepository;

        public RecruiterController(IUserRepository<Recruiter> recruiterRepository)
        {
            this.recruiterRepository = recruiterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecruiters()
        {
            var recruiter = await recruiterRepository.GetAllAsync();

            return Ok(recruiter.Select(recruiter => recruiter.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRecruiter(Guid id)
        {
            var recruiter = await recruiterRepository.GetAsync(id);

            if (recruiter == null)
                return NotFound();

            return Ok(recruiter.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(Guid id)
        {
            try
            {
                await recruiterRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Deleted recruiter");
        }
    }
}
