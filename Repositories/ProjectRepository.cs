using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using MongoDB.Driver;
using static CastingWebAPI.Settings;
namespace CastingWebAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
       

        private readonly IMongoCollection<Project> projectsCollection;
        public ProjectRepository(IMongoClient client) {
            IMongoDatabase db = client.GetDatabase(DATABASE_NAME);
            projectsCollection = db.GetCollection<Project>(PROJECTS_COLLECTION);
        }

        public async Task<Project> AddOneAsync(Project project)
        {
           await projectsCollection.InsertOneAsync(project);
            return project;
        }

        public async Task DeleteAsync(Guid id)
        {
            await projectsCollection.FindOneAndDeleteAsync(project => project.Id == id);    
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var projects = await projectsCollection.Find(x => true).ToListAsync();
            return projects;
        }

        public async Task<Project> GetAsync(Guid id)
        {
            var project = await projectsCollection.Find(project => project.Id == id).SingleOrDefaultAsync();
            return project;
        }

        public async Task<Project> UpdateAsync(Guid id, Project newProject)
        {
            await projectsCollection.FindOneAndReplaceAsync(project => project.Id == id, newProject);
            return newProject;
        }
    }
}
