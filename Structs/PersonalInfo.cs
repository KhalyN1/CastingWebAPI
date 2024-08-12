using CastingWebAPI.Enums;

namespace CastingWebAPI.Structs
{
    public struct PersonalInfo
    {
        public HairColor hairColor;
        public EyeColor eyeColor;
        public Tuple<int, int> height_range;
    }
}
