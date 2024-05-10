namespace EduVerse.UnitTests.Services
{
    public class ScheduleServiceTests
    {
        private readonly IScheduleService _scheduleService;

        private readonly Mock<IScheduleRepository> _scheduleRepository;
        private readonly Mock<IGradeRepository> _gradeRepository;
        private readonly Mock<IAttendanceRepository> _attendanceRepository;
        private readonly Mock<IMapper> _mapper;

        private readonly ScheduleEntity _scheduleFakeEntity = new()
        {
            Id = 1,
            LessonTheme = "Numbers",
            DayOfWeek = "MON",
            Time = TimeOnly.Parse("08:30:00"),
            Lesson = new LessonEntity(),
            LessonId = 1,
            Teacher = new TeacherEntity(),
            TeacherId = 1,
            Group = new GroupEntity(),
            GroupId = 1,
            Attendances = new List<AttendanceEntity>(),
            Grades = new List<GradeEntity>()
        };

        private readonly ScheduleDTO _scheduleFakeDTO = new()
        {
            Id = 1,
            LessonTheme = "Numbers",
            DayOfWeek = "MON",
            Time = TimeOnly.Parse("08:30:00"),
            LessonId = 1,
            TeacherId = 1,
            GroupId = 1
        };

        public ScheduleServiceTests()
        {
            _scheduleRepository = new Mock<IScheduleRepository>();
            _gradeRepository = new Mock<IGradeRepository>();
            _attendanceRepository = new Mock<IAttendanceRepository>();
            _mapper = new Mock<IMapper>();

            _scheduleService = new ScheduleService(_scheduleRepository.Object, _gradeRepository.Object, _attendanceRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ListAsync_WithoutConnectionToDb_ThrowsSqlException()
        {
            // Arrange
            var sqlEx = MakeSqlException();
            _scheduleRepository.Setup(s => s.ListAllAsync()).ThrowsAsync(sqlEx);

            // Act and Assert
            await Assert.ThrowsAsync<SqlException>(async () => await _scheduleService.ListAsync());
        }

        private SqlException MakeSqlException()
        {
            SqlException exception = null!;

            try
            {
                SqlConnection conn = new SqlConnection("Connection Timeout=1");
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }

            return exception;
        }
    }
}
