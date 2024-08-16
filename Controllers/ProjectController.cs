using CastingWebAPI.Dtos;
using CastingWebAPI.Models;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastingWebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IUserRepository userRepository;

        public ProjectController(IProjectRepository projectRepository, IUserRepository userRepository) {
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            var projects = await projectRepository.GetAllAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById(Guid id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            if (project is null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject([FromBody] Project project)
        {
            if (project is null)
                return BadRequest();

            var recruiter = userRepository.GetRecruiterByIdAsync(project.recruiterId).Result;
            if (recruiter is null)
                return BadRequest("No recruiter to add project to");

            try
            {
                await projectRepository.AddProjectAsync(project);
                recruiter.Projects.Add(project);
                await userRepository.UpdateUserAsync(project.recruiterId, recruiter);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

            return Ok(project);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDto>> DeleteProject(Guid id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            if (project is null)
                return NotFound();

            try
            {
                await projectRepository.DeleteProjectByIdAsync(id);

            } catch (Exception ex) { 
                return BadRequest(ex.Message); 
            }
            
            return Ok("Deleted project with id" + id);
        }
    }
}
