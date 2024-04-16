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
        [Route("/teacher/{id}")]
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
        public async Task<ActionResult> GetTeachers()
        {
            try
            {
                var result = await _teacherService.ListAsync();
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
    }
}
