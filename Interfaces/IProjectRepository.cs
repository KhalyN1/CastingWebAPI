using CastingWebAPI.Models;

namespace CastingWebAPI.Interfaces
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAllAsync();
        public Task<Project> GetByIdAsync(Guid id);
       // public Task<IEnumerable<Project>> GetByRecruiterIdAsync(Guid recruiterId);
        public Task<Project> AddProjectAsync(Project project);   
        public Task<Project> UpdateProjectAsync(Guid id, Project newProject);
        public Task DeleteProjectByIdAsync(Guid id);

    }
}
