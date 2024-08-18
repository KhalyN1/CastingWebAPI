using CastingWebAPI.Structs;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace CastingWebAPI.Dtos
{
    public class ActorDto : UserDto
    {
        [BsonElement("Premium")]
        public bool hasPremium { get; set; } = false;
        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.Document)]
        public PersonalInfo? personalInfo { get; set; }
    }
}
