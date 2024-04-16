namespace EduVerse.API.Models.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string LessonTheme { get; set; } = null!;
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly Time { get; set; }
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
    }
}
