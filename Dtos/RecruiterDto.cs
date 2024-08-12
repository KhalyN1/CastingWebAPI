using CastingWebAPI.Models;

namespace CastingWebAPI.Dtos
{
    public class RecruiterDto : UserDto
    {
        public List<Project> Projects { get; set; } = new List<Project>();  
    }
}
