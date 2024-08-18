using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using MongoDB.Driver;
using static CastingWebAPI.Settings;

namespace CastingWebAPI.Repositories
{
    public class ActorRepository : IUserRepository<Actor>
    {
        private readonly IMongoCollection<Actor> actorsCollection;
        
        public ActorRepository(IMongoClient client)
        {
            IMongoDatabase db = client.GetDatabase(DATABASE_NAME);
            actorsCollection = db.GetCollection<Actor>(ACTORS_COLLECTION);
        }
        public async Task<Actor> AddOneAsync(Actor actor)
        {
            await actorsCollection.InsertOneAsync(actor);

            return actor;
        }

        public async Task DeleteAsync(Guid id)
        {
            await actorsCollection.DeleteOneAsync(actor  => actor.Id == id);
        }

        public async Task<bool> ExistsByEmail(string email)
        {
          return await actorsCollection.Find(x => x.Email == email).AnyAsync();
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            return await actorsCollection.Find(x => x.Username == username).AnyAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await actorsCollection.Find(x => true).ToListAsync();

            return actors;
        }

        public async Task<Actor> GetAsync(Guid id)
        {
            var actor = await actorsCollection.Find(x => x.Id == id).SingleOrDefaultAsync();

            return actor;
        }

        public async Task<Actor> UpdateAsync(Guid id, Actor actor)
        {
            await actorsCollection.FindOneAndReplaceAsync(x  => x.Id == id, actor);

            return actor;
        }

        public async Task<Actor> GetByUsernameOrEmail(string usernameOrEmail)
        {
            var actor = await actorsCollection.Find(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail).SingleOrDefaultAsync();

            return actor;
        }
    }
}
