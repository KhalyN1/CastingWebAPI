namespace CastingWebAPI.Models
{
    public class UserSignUpForm
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateOnly birthDate { get; set; }
        public string userType { get; set; } 
        public string Password { get; set; }
    }
}
