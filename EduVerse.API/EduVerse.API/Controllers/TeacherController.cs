namespace EduVerse.API.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;
        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/teacher/profile")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult> GetProfile()
        {
            try
            {
                var user = HttpContext.User;
                var userEmailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                if (userEmailClaim is null)
                {
                    throw new ArgumentException("Email claim not found in token.");
                }

                var result = await _teacherService.GetAsync(userEmailClaim.Value);
                _logger.LogInformation($"Teacher whith email ={userEmailClaim.Value} were received profile");
                return Ok(result);
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

        [HttpGet]
        [Route("/teacher/{id}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult> GetTeacher(int id)
        {
            try
            {
                var result = await _teacherService.GetAsync(id);
                _logger.LogInformation($"Teacher whith id ={id} were received");
                return Ok(result);
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

        [HttpGet]
        [Route("/teachers")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult> GetTeachers(string? filterOn, string? filterQuery)
        {
            try
            {
                var result = await _teacherService.ListAsync(filterOn, filterQuery);
                _logger.LogInformation($"Teachers (count = {result.Count}) were received");
                return Ok(result);
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

        [HttpPost]
        [Route("/teacher")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTeacher(TeacherDTO teacher)
        {
            try
            {
                var result = await _teacherService.AddAsync(teacher);
                _logger.LogInformation($"Teacher with id = {result} was added");
                return Ok(result);
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

        [HttpPut]
        [Route("/teacher")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateTeacher(TeacherDTO teacher)
        {
            try
            {
                var result = await _teacherService.UpdateAsync(teacher);
                _logger.LogInformation($"Teacher with id = {result} was updated");
                return Ok(result);
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

        [HttpDelete]
        [Route("/teacher/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            try
            {
                var result = await _teacherService.DeleteAsync(id);
                _logger.LogInformation($"Teacher whith id ={id} were deleted");
                return Ok(result);
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
