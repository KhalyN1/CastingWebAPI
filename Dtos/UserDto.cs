namespace CastingWebAPI.Dtos
{
    public abstract class UserDto
    {
        public Guid Id { get; init; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public byte[] salt { get; set; }
        public DateTime createdAt { get; init; } = DateTime.Now;
        public DateOnly birthDate { get; set; }
    }
}
