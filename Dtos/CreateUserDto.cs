using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CastingWebAPI.Dtos
{
    public class CreateUserDto
    {
        [BsonRequired]
        public string Username { get; set; }
        [BsonRequired]
        [EmailAddress]
        public string Email { get; set; }
        [BsonRequired]
        public DateOnly birthDate { get; set; }
        [BsonRequired]
        public string userType { get; set; }
        [BsonRequired]
        public string Password { get; set; }
    }
}
