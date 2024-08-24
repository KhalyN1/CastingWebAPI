using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace CastingWebAPI.Dtos
{
    public class LoginDto
    {
        [BsonRequired]
        public string Username { get; set; }
        [BsonRequired]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
