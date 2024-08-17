
using CastingWebAPI.Structs;
namespace CastingWebAPI.Models
{
    public class Actor : User
    {
        public bool hasPremium { get; set; } = false;
        public PersonalInfo personalInfo { get; set; }
    }

   
}
