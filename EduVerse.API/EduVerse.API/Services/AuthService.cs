namespace EduVerse.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthService(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserRequest registerUser)
        {
            ValidateUser(registerUser);

            var identityUser = new IdentityUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerUser.Password);

            if (!identityResult.Succeeded)
            {
                throw new ArgumentException("User registration did not take place");
            }

            identityResult = await _userManager.AddToRolesAsync(identityUser, registerUser.Roles);

            return identityResult.Succeeded;
        }

        public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user is null)
            {
                throw new ArgumentException("Username or password incorect");
            }

            var passwordCheckResult = await _userManager.CheckPasswordAsync(user, loginUser.Password);

            if (!passwordCheckResult)
            {
                throw new ArgumentException("Username or password incorect");
            }

            var rolesList = await _userManager.GetRolesAsync(user);

            if (rolesList is null)
            {
                throw new ArgumentException("User no roles have been assigned");
            }

            var jwtToken = await _tokenRepository.CreateJWTTokenAsync(user, rolesList.ToList());

            return new LoginUserResponse() { JWTToken = jwtToken };
        }

        private void ValidateUser(RegisterUserRequest user)
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
