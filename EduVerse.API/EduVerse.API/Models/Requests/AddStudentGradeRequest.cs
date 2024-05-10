namespace EduVerse.API.Models.Requests
{
    public class AddStudentGradeRequest
    {
        public int Mark { get; set; }
        public string Competence { get; set; } = null!;
        public int StudentId { get; set; }
    }
}
