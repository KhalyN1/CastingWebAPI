using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace CastingWebAPI.Models
{
    public abstract class User
    {

        [BsonId]
        public Guid Id { get; init; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Salt")]
        public byte[] salt { get; set; }
        [BsonElement("CreatedAt")]
        public DateTime createdAt { get; init; } = DateTime.Now;
        [BsonElement("BirthDate")]
        public DateOnly birthDate { get; set; } 
    }
}
