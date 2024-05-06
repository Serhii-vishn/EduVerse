namespace EduVerse.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO registerUser)
        {
            ValidateUser(registerUser);

            var identityUser = new IdentityUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerUser.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerUser.Roles);

                return identityResult.Succeeded;
            }

            return false;
        }

        private void ValidateUser(RegisterUserDTO user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User is empty");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Username is required", nameof(user.Username));
            }
            else
            {
                user.Username = user.Username.Trim();

                const string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                if (!Regex.IsMatch(user.Username, emailPattern))
                {
                    throw new ArgumentException(nameof(user.Username), "Username (email) is invalid");
                }
            }

            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 7)
            {
                throw new ArgumentException("Password is required and should be minimum 7 characters long", nameof(user.Password));
            }

            if (user.Roles is null || !user.Roles.Any())
            {
                throw new ArgumentNullException(nameof(user.Roles), "User roles are empty");
            }
        }
    }
}
