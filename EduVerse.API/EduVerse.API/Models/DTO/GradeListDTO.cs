namespace EduVerse.API.Models.DTO
{
    public class GradeListDTO
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public string Competence { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }
        public int ScheduleLessonId { get; set; }
    }
}
