using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace CastingWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository() {
            _users = new List<User>();
        }

        public UserRepository(List<User> users) {
            _users = users;
        }
        public async Task<User> AddUserAsync(User user)
        {
             _users.Add(user);
            return user;
        }

        public async Task DeleteUserByIdAsync(Guid id)
        {
            User user = GetUserByIdAsync(id).Result;
            _users.Remove(user);
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return _users.OfType<Actor>();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return _users;
        }

        public async Task<IEnumerable<Recruiter>> GetAllRecruitersAsync()
        {
            return _users.OfType<Recruiter>();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User user = _users.Where(u => u.Id == id).FirstOrDefault();

            return user;
        }

        public async Task<User> UpdateUserAsync(Guid id, User newUser)
        {
            User user = GetUserByIdAsync(id).Result;

            user = newUser;

            return newUser;
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            var users = _users.Where(user => user.Username == username);

            return users.Any();
        } 

        public async Task<bool> ExistsByEmail(string email)
        {
            var users = _users.Where(user => user.Email == email);

            return users.Any();
        }
    }
}
