using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using MongoDB.Driver;
using static CastingWebAPI.Settings;
namespace CastingWebAPI.Repositories
{
    public class RecruiterRepository : IUserRepository<Recruiter>
    {
        private readonly IMongoCollection<Recruiter> recruitersCollection;

        public RecruiterRepository(IMongoClient client) {

            IMongoDatabase db = client.GetDatabase(DATABASE_NAME);
            recruitersCollection = db.GetCollection<Recruiter>(RECRUITERS_COLLECTION);
        }

        public async Task<Recruiter> AddOneAsync(Recruiter recruiter)
        {
            await recruitersCollection.InsertOneAsync(recruiter);

            return recruiter;
        }

        public async Task DeleteAsync(Guid id)
        {
            await recruitersCollection.DeleteOneAsync(recruiter  => recruiter.Id == id);
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await recruitersCollection.Find(x => x.Email == email).AnyAsync();
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            return await recruitersCollection.Find(x => x.Username == username).AnyAsync();
        }

        public async Task<IEnumerable<Recruiter>> GetAllAsync()
        {
            var recruiters = await recruitersCollection.Find(x => true).ToListAsync();

            return recruiters;
        }

        public async Task<Recruiter> GetAsync(Guid id)
        {
            var recruiter = await recruitersCollection.Find(x => x.Id == id).SingleOrDefaultAsync();

            return recruiter;
        }

        public async Task<Recruiter> UpdateAsync(Guid id, Recruiter recruiter)
        {
            await recruitersCollection.FindOneAndReplaceAsync(x => x.Id == id, recruiter);

            return recruiter;   
        }

        public async Task<Recruiter> GetByUsernameOrEmail(string usernameOrEmail)
        {
            var recruiter = await recruitersCollection.Find(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail).SingleOrDefaultAsync();

            return recruiter;
        }
    }
}
