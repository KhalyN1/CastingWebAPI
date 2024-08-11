namespace CastingWebAPI.Models
{
    public abstract class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public byte[] salt { get; set; }
        public DateTime createdAt { get; set; }
        public DateOnly birthDate { get; set; } 
    }
}
