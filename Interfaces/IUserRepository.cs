using CastingWebAPI.Models;
namespace CastingWebAPI.Interfaces
{
    public interface IUserRepository<T> : IMongoRepository<T> where T: User
    {
      
        public Task<bool> ExistsByUsername(string username);

        public Task<bool> ExistsByEmail(string email);   

        public Task<T> GetByUsernameOrEmail(string usernameOrEmail);
    }
}
