using CastingWebAPI.Enums;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using CastingWebAPI.Structs;
namespace CastingWebAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IUserRepository<Actor> actorRepository;

        public RoleService(IRoleRepository roleRepository, IProjectRepository projectRepository, IUserRepository<Actor> actorRepository)
        {
            this.roleRepository = roleRepository;
            this.projectRepository = projectRepository;
            this.actorRepository = actorRepository;
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            await roleRepository.DeleteAsync(id);
        }

        public async Task<Role> GetRoleAsync(Guid id)
        {
            var role = await roleRepository.GetAsync(id);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var roles = await roleRepository.GetAllAsync();
            return roles;
        }

        public async Task<Role> UpdateRequirements(Guid id, HairColor? hairColor, EyeColor? eyeColor, int? height)
        {
            var role = await roleRepository.GetAsync(id);

            if (role == null)
            {
                throw new InvalidOperationException("Role doesn't exist");
            }

            var info = role.Requirements ?? new PersonalInfo();

            info.HairColor = hairColor ?? info.HairColor;
            info.EyeColor = eyeColor ?? info.EyeColor;
            info.Height = height ?? info.Height;

            role.Requirements = info;

            await roleRepository.UpdateAsync(id, role);

            return role;
        }

        public async Task<Role> AddRoleAsync(Guid projectId, Role role)
        {
            var project = await projectRepository.GetAsync(projectId);

            project.Roles.Add(role);

            await projectRepository.UpdateAsync(projectId, project);
            await roleRepository.AddOneAsync(role);

            return role;
        }
    }
}
