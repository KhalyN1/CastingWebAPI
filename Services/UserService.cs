using CastingWebAPI.Dtos;
using CastingWebAPI.Extensions;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Models;
using CastingWebAPI.Structs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;

namespace CastingWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<Actor> actorRepository;
        private readonly IUserRepository<Recruiter> recruiterRepository;
        private readonly IPasswordService passwordService;

        public UserService(IUserRepository<Actor> actorRepository, IUserRepository<Recruiter> recruiterRepository, 
                           IPasswordService passwordService)
        {
            this.actorRepository = actorRepository;
            this.recruiterRepository = recruiterRepository;
            this.passwordService = passwordService;
        }
        public async Task<string> LoginAsync(LoginDto request)
        {
            if (!actorRepository.ExistsByUsername(request.Username).Result &&
                !recruiterRepository.ExistsByUsername(request.Username).Result &&
                !actorRepository.ExistsByEmail(request.Username).Result &&
                !recruiterRepository.ExistsByEmail(request.Username).Result)
                throw new Exception("Username or Email does not exist");

            var actor = await actorRepository.GetByUsernameOrEmail(request.Username);

            if (actor != null)
            {
                var allowed = passwordService.VerifyPassword(request.Password, actor.PasswordHash, actor.salt);
                if (!allowed)
                    throw new UnauthorizedAccessException("Invalid Password");

                return $"Logged in as {actor.Username}";
            }

            var recruiter = await recruiterRepository.GetByUsernameOrEmail(request.Username);

            if (recruiter != null)
            {
                var allowed = passwordService.VerifyPassword(request.Password, recruiter.PasswordHash, recruiter.salt);
                if (!allowed)
                   throw new UnauthorizedAccessException("Invalid Password");

                return $"Logged in as {recruiter.Username}";
            }

            throw new Exception("User could not be found");

        }

        public async Task<User> SignUpAsync(CreateUserDto request)
        {

            if (request.userType == "Actor")
            {
                if (actorRepository.ExistsByUsername(request.Username).Result)
                    throw new Exception("Username already taken");

                if (actorRepository.ExistsByEmail(request.Email).Result)
                    throw new Exception("Email already in use");

                var actor = new Actor()
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = passwordService.HashPassword(request.Password, out byte[] salt),
                    salt = salt,
                    birthDate = request.birthDate,
                    personalInfo = new PersonalInfo() { }
                };

                await actorRepository.AddOneAsync(actor);
                return actor;

            } 

            else if (request.userType == "Recruiter")
            {
                if (recruiterRepository.ExistsByUsername(request.Username).Result)
                    throw new Exception("Username already taken");

                if (recruiterRepository.ExistsByEmail(request.Email).Result)
                    throw new Exception("Email already in use");

                var recruiter = new Recruiter()
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = passwordService.HashPassword(request.Password, out byte[] salt),
                    salt = salt,
                    birthDate = request.birthDate,
                    Projects = new List<Project>()
                };

                await recruiterRepository.AddOneAsync(recruiter);
                return recruiter;
            }

            else throw new Exception("Incorrect user type");

            

         
        }
    }
}
