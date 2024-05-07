namespace EduVerse.API.Models.Requests
{
    public class RegisterUserRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
