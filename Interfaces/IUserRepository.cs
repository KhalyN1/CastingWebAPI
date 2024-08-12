using CastingWebAPI.Models;
namespace CastingWebAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<IEnumerable<Actor>> GetAllActorsAsync();

        public Task<IEnumerable<Recruiter>> GetAllRecruitersAsync();

        public Task<User> GetUserByIdAsync(Guid id);

        public Task<User> AddUserAsync(User user);

        public Task<User> UpdateUserAsync(Guid id, User newUser);

        public Task DeleteUserByIdAsync(Guid id);

        public Task<bool> ExistsByUsername(string username);

        public Task<bool> ExistsByEmail(string email);   

    }
}
