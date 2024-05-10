namespace EduVerse.API.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService scheduleService, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/schedule")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult> GetSchedule()
        {
            try
            {
                var result = await _scheduleService.ListAsync();
                _logger.LogInformation($"Schedule (count = {result.Count}) were received");
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
        [Route("/schedule/lesson/{id}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult> GetScheduledLesson(int id)
        {
            try
            {
                var result = await _scheduleService.GetByLessonIdAsync(id);
                _logger.LogInformation($"Lesson in schedule whith id ={id} were received");
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
        [Route("/schedule/lesson/{lessonId}/student-grade")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult> GetScheduledLesson([FromForm] AddStudentGradeRequest gradeRequest, int lessonId)
        {
            try
            {
                await _scheduleService.AddStudentGrade(lessonId, gradeRequest);
                _logger.LogInformation($"Assigned grade to a student with id - {gradeRequest.StudentId}, lessonId - {lessonId}");
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

        [HttpPut]
        [Route("/schedule")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateSchedule(ScheduleDTO schedule)
        {
            try
            {
                var result = await _scheduleService.UpdateAsync(schedule);
                _logger.LogInformation($"Schedule with id = {result} was updated");
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
