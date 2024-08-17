using CastingWebAPI.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace CastingWebAPI.Structs
{
    public class PersonalInfo
    {
        [BsonElement("HairColor")]
        public HairColor? HairColor;
        [BsonElement("EyeColor")]
        public EyeColor? EyeColor;
        [BsonElement("Height")]
        public int? Height;
    }
}
