using CastingWebAPI.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace CastingWebAPI.Structs
{
    public class PersonalInfo
    {
        [BsonElement("HairColor")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public HairColor? HairColor;
        [BsonElement("EyeColor")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public EyeColor? EyeColor;
        [BsonElement("Height")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int? Height;
    }
}
