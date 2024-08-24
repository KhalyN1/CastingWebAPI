using CastingWebAPI.Dtos;
using CastingWebAPI.Enums;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using CastingWebAPI.Structs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastingWebAPI.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles() {
            try
            {
                var roles = await roleService.GetRolesAsync();
                return Ok(roles);
            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(Guid id)
        {
            try
            {
                var role = await roleService.GetRoleAsync(id);
                return Ok(role);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleDto request)
        {
            var role = new Role()
            {
                Name = request.Name,
                Description = request.Description,
                projectId = request.projectId,
                Type = request.Type,
                Requirements = new Structs.PersonalInfo()
                {
                    EyeColor = request.EyeColor,
                    HairColor = request.HairColor,
                    Height = request.Height
                }
            };

            try
            {
                await roleService.AddRoleAsync(request.projectId, role);
                return Ok(role);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
               
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                await roleService.DeleteRoleAsync(id);
                return Ok("deleted role");
            } catch (Exception ex)  {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequirements(Guid id,
                                                            [FromQuery] HairColor? hairColor,
                                                            [FromQuery] EyeColor? eyeColor,
                                                            [FromQuery] int? height)
        {
            try
            {
                await roleService.UpdateRequirements(id, hairColor, eyeColor, height);
                return Ok("Update role " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
