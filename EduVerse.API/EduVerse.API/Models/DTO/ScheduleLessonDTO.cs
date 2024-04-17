namespace EduVerse.API.Models.DTO
{
    public class ScheduleLessonDTO
    {
        public int Id { get; set; }
        public string LessonTheme { get; set; } = null!;
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly Time { get; set; }
        public string LessonName { get; set; } = null!;
        public string TeacherFullName { get; set; } = null!;
        public string GroupName { get; set; } = null!;
        public IList<StudentListDTO> Students { get; set; } = new List<StudentListDTO>();
        public IList<AttendanceEntity> Attendances { get; set; } = new List<AttendanceEntity>();
        public IList<GradeEntity> Grades { get; set; } = new List<GradeEntity>();
    }
}
