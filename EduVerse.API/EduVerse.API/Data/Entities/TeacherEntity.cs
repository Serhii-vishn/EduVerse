namespace EduVerse.API.Data.Entities
{
    public class TeacherEntity
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
        public string? PictureFileName { get; set; }

        public IList<GroupEntity> Groups { get; set; } = new List<GroupEntity>();

        public IList<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();
    }
}
