namespace CastingWebAPI.Models
{
    public class UserSignUpForm
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string birthDate { get; set; }
        public int userType { get; set; }
        public string Password { get; set; }
    }
}
