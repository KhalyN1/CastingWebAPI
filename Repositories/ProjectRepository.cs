using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;

namespace CastingWebAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects;
        public ProjectRepository() {
            _projects = new List<Project>();
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
           _projects.Add(project);
            return project;
        }

        public async Task<Project> DeleteProjectByIdAsync(Guid id)
        {
            Project project = GetByIdAsync(id).Result;

            _projects.Remove(project);

            return project;

        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return _projects;
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return _projects.Where(project => project.Id == id).FirstOrDefault();
        }

        public async Task<Project> UpdateProjectAsync(Guid id, Project newProject)
        {
            Project project = GetByIdAsync(id).Result;

            project = newProject;

            return newProject;
        }
    }
}
