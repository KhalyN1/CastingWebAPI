using CastingWebAPI.Enums;
using CastingWebAPI.Structs;

namespace CastingWebAPI.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public Guid projectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType Type { get; set; }
        public PersonalInfo Requirements { get; set; }
    }
}
