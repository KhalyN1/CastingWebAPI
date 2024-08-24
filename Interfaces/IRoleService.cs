using CastingWebAPI.Enums;
using CastingWebAPI.Models;

namespace CastingWebAPI.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleAsync(Guid id);

        Task<Role> UpdateRequirements(Guid id, HairColor? hairColor, EyeColor? eyeColor, int? height);

        Task DeleteRoleAsync(Guid id);

        Task<Role> AddRoleAsync(Guid projectId, Role role);    
    }
}
