using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using MongoDB.Bson;
using static CastingWebAPI.Settings;
using System.Net;

namespace CastingWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> usersCollection;
        public UserRepository(IMongoClient client) {
            

            IMongoDatabase db = client.GetDatabase(DATABASE_NAME);
            usersCollection = db.GetCollection<User>(USERS_COLLECTION);
        }

        public async Task<User> AddUserAsync(User user)
        {
             await usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task DeleteUserByIdAsync(Guid id)
        {
            await usersCollection.FindOneAndDeleteAsync((user => user.Id == id));
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            var users = await usersCollection.Find(user => user is Actor).ToListAsync();
            return users.OfType<Actor>();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await usersCollection.Find(new BsonDocument()).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<Recruiter>> GetAllRecruitersAsync()
        {
            var users = await usersCollection.Find(user => user is Recruiter).ToListAsync();
            return users.OfType<Recruiter>();
        }

        public async Task<Recruiter> GetRecruiterByIdAsync(Guid id)
        {
            var recruiter = await usersCollection.Find(user => user.Id == id && user is Recruiter).SingleOrDefaultAsync();
            return (Recruiter) recruiter;
        }

        public async Task<Actor> GetActorByIdAsync(Guid id)
        {
            var actor = await usersCollection.Find(user => user.Id == id && user is Actor).SingleOrDefaultAsync();
            return (Actor) actor;
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await usersCollection.Find(user => user.Id == id).SingleOrDefaultAsync();

            return user;
        }

        public async Task<User> UpdateUserAsync(Guid id, User newUser)
        {
            await usersCollection.FindOneAndReplaceAsync(user => user.Id == id, newUser);

            return newUser;
        }

        public async Task<bool> ExistsByEmail(string email)
        {

            var exists = await usersCollection.Find(user => user.Email == email).AnyAsync();
            return exists;
        }

        public async Task<bool> ExistsByUsername(string name)
        {

            var exists = await usersCollection.Find(user => user.Username == name).AnyAsync();
            return exists;
        }
    }
}
