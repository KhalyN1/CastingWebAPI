using CastingWebAPI.Enums;
using CastingWebAPI.Structs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CastingWebAPI.Models
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ProjectId")]
        [BsonRequired]
        public Guid projectId { get; set; }
        [BsonRepresentation(BsonType.String)]
        [BsonElement("Name")]
       
        public string Name { get; set; }
        [BsonRepresentation(BsonType.String)]
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonRepresentation(BsonType.String)]
        [BsonElement("Description")]
        public RoleType Type { get; set; }
        [BsonRepresentation(BsonType.Document)]
        [BsonElement("Requirements")]
        public PersonalInfo Requirements { get; set; }
    }
}
