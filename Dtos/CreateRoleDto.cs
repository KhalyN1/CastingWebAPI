using CastingWebAPI.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CastingWebAPI.Dtos
{
    public class CreateRoleDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ProjectId")]
        [BsonRequired]
        public Guid projectId { get; set; }
        [BsonRequired]
        public string Name { get; set; }
        [BsonRequired]
        public string Description { get; set; }
        [BsonRequired]
        public RoleType Type { get; set; }
        [BsonIgnoreIfNull]
        public HairColor HairColor { get; set; }
        [BsonIgnoreIfNull]
        public EyeColor EyeColor { get; set; }
        [BsonIgnoreIfNull]
        public int Height { get; set; }
    }
}
