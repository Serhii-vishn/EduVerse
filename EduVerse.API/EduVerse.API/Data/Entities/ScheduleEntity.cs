namespace EduVerse.API.Data.Entities
{
    public class ScheduleEntity
    {
        public int Id { get; set; }
        public string LessonTheme { get; set; } = null!;
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly Time { get; set; }

        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; } = null!;

        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; } = null!;

        public int GroupId { get; set; }
        public GroupEntity Group { get; set; } = null!;

        public IList<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();

        public IList<GradeEntity> Grades { get; set; } = new List<GradeEntity>();
    }
}
