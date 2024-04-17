namespace EduVerse.API.Models.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Education { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;

        public IList<GroupListDTO> Groups { get; set; } = new List<GroupListDTO>();

        public IList<LessonListDTO> Lessons { get; set; } = new List<LessonListDTO>();
    }
}
