using CastingWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CastingWebAPI.Models;
using CastingWebAPI.Extensions;
using CastingWebAPI.Enums;
using CastingWebAPI.Structs;
using Microsoft.AspNetCore.Mvc.Routing;
namespace CastingWebAPI.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IUserRepository<Actor> actorRepository;
        public ActorController(IUserRepository<Actor> actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetActors()
        {
            var actors = await actorRepository.GetAllAsync();

            return Ok(actors.Select(actor => actor.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetActor(Guid id)
        {
            var actor = await actorRepository.GetAsync(id);

            if (actor == null)
                return NotFound();

            return Ok(actor.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(Guid id)
        {
            try
            {
                await actorRepository.DeleteAsync(id);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
            return Ok("Deleted actor");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonalInfo(Guid id,
                                                           [FromQuery] HairColor? hairColor,
                                                           [FromQuery] EyeColor? eyeColor,
                                                           [FromQuery] int? height)
        {

            var actor = await actorRepository.GetAsync(id);
            if (actor == null) return BadRequest("User does not exist");
            
            var info = actor.personalInfo ?? new PersonalInfo() { };

            info.HairColor = hairColor ?? info.HairColor;
            info.EyeColor = eyeColor ?? info.EyeColor;
            info.Height = height ?? info.Height;

            actor.personalInfo = info;

            await actorRepository.UpdateAsync(id, actor);

            return Ok(actor);

        }

        [HttpPut("{id}/{premium}")] 
        public async Task<ActionResult> UpdatePremiumStatus(Guid id, [FromQuery] bool premium)
        {
            var actor = await actorRepository.GetAsync(id);
            if (actor == null) return BadRequest("User does not exist");

           actor.hasPremium = premium;

            await actorRepository.UpdateAsync(id, actor);

            return Ok(Json(actor.Id, actor.hasPremium));
        }
    }
}
