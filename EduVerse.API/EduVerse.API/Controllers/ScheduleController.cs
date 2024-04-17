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
        public async Task<ActionResult> GetSchedule()
        {
            try
            {
                var result = await _scheduleService.ListAsync();
                _logger.LogInformation($"Schedule (count = {result.Count}) were received");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/schedule/lesson/{id}")]
        public async Task<ActionResult> GetSchedule(int id)
        {
            try
            {
                var result = await _scheduleService.GetLessonByScheduleIdAsync(id);
                _logger.LogInformation($"Lesson in schedule whith id ={id} were received");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("/schedule")]
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
