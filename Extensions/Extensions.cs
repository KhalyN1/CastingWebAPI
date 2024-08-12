using CastingWebAPI.Dtos;
using CastingWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace CastingWebAPI.Extensions
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            if (user is Actor)
            {
                return new ActorDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    salt = user.salt,
                    Email = user.Email,
                    hasPremium = ((Actor)user).hasPremium,
                    personalInfo = ((Actor)user).personalInfo
                };
            }

            return new RecruiterDto
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                salt = user.salt,
                Email = user.Email,
                Projects = ((Recruiter)user).Projects
            };
        }

        public static ProjectDto AsDto(this Project project)
        {
            return new ProjectDto()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Location = project.Location,
                recruiterId = project.recruiterId,
            };
        }
    }
}
