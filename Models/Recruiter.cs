namespace CastingWebAPI.Models
{
    public class Recruiter : User
    {
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
