namespace EduVerse.API.Models.DTO
{
    public class RegisterUserDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
