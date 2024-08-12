namespace CastingWebAPI.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Guid recruiterId { get; init; }
    }
}
