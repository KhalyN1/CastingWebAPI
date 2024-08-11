using CastingWebAPI.Enums;

namespace CastingWebAPI.Models
{
    public class Actor : User
    {
        public bool hasPremium { get; set; }    
        public PersonalInfo? personalInfo { get; set; }
    }

    public struct PersonalInfo
    {
        public HairColor hairColor;
        public EyeColor eyeColor;
        public Tuple<int, int> height_range;
    }
}
