namespace EduVerse.API.Models.DTO
{
    public class AttedanceDTO
    {
        public string Status { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }
        public int ScheduleLessonId { get; set; }
    }
}
