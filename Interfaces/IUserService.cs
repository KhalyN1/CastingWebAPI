using CastingWebAPI.Dtos;
using CastingWebAPI.Models;
namespace CastingWebAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> SignUpAsync(CreateUserDto user);
        Task<string> LoginAsync(LoginDto user);
    }
}
