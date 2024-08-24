using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using MongoDB.Driver;
using static CastingWebAPI.Settings;
namespace CastingWebAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMongoCollection<Role> rolesCollection;

        public RoleRepository(IMongoClient client)
        {
            IMongoDatabase db = client.GetDatabase(DATABASE_NAME);
            rolesCollection = db.GetCollection<Role>(ROLES_COLLECTION);
        }
        public async Task<Role> AddOneAsync(Role role)
        {
            await rolesCollection.InsertOneAsync(role);
            return role;
        }

        public async Task DeleteAsync(Guid id)
        {
            await rolesCollection.DeleteOneAsync(role => role.Id == id);

        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var roles = await rolesCollection.Find(role => true).ToListAsync();
            return roles;
        }

        public async Task<Role> GetAsync(Guid id)
        {
            var role = await rolesCollection.Find(role => role.Id == id).SingleOrDefaultAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Guid id, Role newRole)
        {
            await rolesCollection.FindOneAndReplaceAsync(role => role.Id == id, newRole);
            return newRole;
        }
    }
}
