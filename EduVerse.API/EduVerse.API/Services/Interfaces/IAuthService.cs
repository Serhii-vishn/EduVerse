namespace EduVerse.API.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> RegisterUserAsync(RegisterUserDTO registerUser);
    }
}
