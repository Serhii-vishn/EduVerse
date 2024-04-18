namespace EduVerse.API.Data.Entities
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public string Competence { get; set; } = null!;
        public DateOnly Date { get; set; }

        public int StudentId { get; set; }
        public StudentEntity Student { get; set; } = null!;

        public int ScheduleLessonId { get; set; }
        public ScheduleEntity ScheduleLesson { get; set; } = null!;
    }
}
