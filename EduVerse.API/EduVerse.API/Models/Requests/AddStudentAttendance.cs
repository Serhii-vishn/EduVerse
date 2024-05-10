namespace EduVerse.API.Models.Requests
{
    public class AddStudentAttendance
    {
        public string Status { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }
    }
}
