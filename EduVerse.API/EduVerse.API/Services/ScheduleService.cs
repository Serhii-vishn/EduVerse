namespace EduVerse.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IGradeRepository gradeRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid schedule id");
            }

            var data = await _scheduleRepository.GetAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Schedule with id = {id} does not exist");
            }

            return _mapper.Map<ScheduleDTO>(data);
        }

        public async Task<ScheduleLessonDTO> GetByLessonIdAsync(int scheduledLessonId)
        {
            if (scheduledLessonId <= 0)
            {
                throw new ArgumentException("Invalid scheduled lesson id");
            }

            var data = await _scheduleRepository.GetAllAsync(scheduledLessonId);

            return _mapper.Map<ScheduleLessonDTO>(data);
        }

        public async Task<IList<ScheduleListDTO>> ListAsync()
        {
            var data = await _scheduleRepository.ListAllAsync();
            return _mapper.Map<IList<ScheduleListDTO>>(data);
        }

        public async Task AddStudentGrade(int lessonId, AddStudentGradeRequest gradeRequest)
        {
            var gradeDto = new GradeDTO
            {
                Mark = gradeRequest.Mark,
                Competence = gradeRequest.Competence,
                Date = DateOnly.FromDateTime(DateTime.Now),
                StudentId = gradeRequest.StudentId,
                ScheduleLessonId = lessonId
            };

            ValidateGrade(gradeDto);

            await _gradeRepository.AddAsync(_mapper.Map<GradeEntity>(gradeDto));
        }

        public async Task<int> UpdateAsync(ScheduleDTO schedule)
        {
            ValidateSchedule(schedule);

            await GetAsync(schedule.Id);

            return await _scheduleRepository.UpdateAsync(_mapper.Map<ScheduleEntity>(schedule));
        }

        private void ValidateSchedule(ScheduleDTO schedule)
        {
            if (schedule is null)
            {
                throw new ArgumentNullException(nameof(schedule), "Schedule is empty");
            }

            if (string.IsNullOrWhiteSpace(schedule.LessonTheme) || schedule.LessonTheme.Length > 35)
            {
                throw new ArgumentException("Lesson theme is required and should be maximum 35 characters long", nameof(schedule.LessonTheme));
            }

            if (string.IsNullOrWhiteSpace(schedule.DayOfWeek) || schedule.DayOfWeek.Length != 3)
            {
                throw new ArgumentException("Day of week is required and should be 3 characters long", nameof(schedule.DayOfWeek));
            }

            schedule.DayOfWeek = schedule.DayOfWeek.ToUpper();

            if (!Enum.TryParse(typeof(DaysOfWeek), schedule.DayOfWeek, out var day) || !Enum.IsDefined(typeof(DaysOfWeek), day))
            {
                throw new ArgumentException("Invalid day of week", nameof(schedule.DayOfWeek));
            }

            if (schedule.Time < TimeOnly.Parse("08:00:00") || schedule.Time > TimeOnly.Parse("20:00:00"))
            {
                throw new ArgumentException("Invalid lesson time start", nameof(schedule.Time));
            }
        }

        private void ValidateGrade(GradeDTO grade)
        {
            if (grade is null)
            {
                throw new ArgumentNullException(nameof(grade), "Grade is empty");
            }

            if (grade.Mark > 12 || grade.Mark <= 0)
            {
                throw new ArgumentException("Grade should be from 1 to 12", nameof(grade.Mark));
            }

            if (string.IsNullOrEmpty(grade.Competence))
            {
                throw new ArgumentException("Grade is required ", nameof(grade.Competence));
            }
            else if (!Enum.TryParse(typeof(GradeCompetences), grade.Competence, out var competence) || !Enum.IsDefined(typeof(GradeCompetences), competence))
            {
                throw new ArgumentException("Invalid competence", nameof(grade.Competence));
            }
        }
    }
}
