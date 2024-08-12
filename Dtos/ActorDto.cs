using CastingWebAPI.Structs;

namespace CastingWebAPI.Dtos
{
    public class ActorDto : UserDto
    {
        public bool hasPremium { get; set; } = false;
        public PersonalInfo? personalInfo { get; set; }
    }
}
