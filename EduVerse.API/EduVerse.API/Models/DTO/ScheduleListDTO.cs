namespace EduVerse.API.Models.DTO
{
    public class ScheduleListDTO
    {
        public int Id { get; set; }
        public string LessonTheme { get; set; } = null!;
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly Time { get; set; }
        public string LessonName { get; set; } = null!;
        public string TeacherFullName { get; set; } = null!;
        public string GroupName { get; set; } = null!;
    }
}
