using EduVerse.API.Services;

namespace EduVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUser)
        {
            try
            {
                var result = await _authService.RegisterUserAsync(registerUser);

                if (!result)
                {
                    throw new ArgumentException("User registration did not take place");
                }

                _logger.LogInformation($"User - {registerUser.Username} were registered");
                return Ok();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500);
            }
        }
    }
}
