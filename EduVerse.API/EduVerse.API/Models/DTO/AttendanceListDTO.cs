namespace EduVerse.API.Models.DTO
{
    public class AttendanceListDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }
        public int ScheduleLessonId { get; set; }
    }
}
