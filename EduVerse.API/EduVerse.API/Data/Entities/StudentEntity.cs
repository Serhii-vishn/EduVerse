namespace EduVerse.API.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PictureFileName { get; set; }

        public int GroupId { get; set; }
        public GroupEntity Group { get; set; } = null!;

        public IList<ParentEntity> Parents { get; set; } = new List<ParentEntity>();

        public IList<AttendanceEntity> Attendance { get; set; } = new List<AttendanceEntity>();

        public IList<GradeEntity> Grades { get; set; } = new List<GradeEntity>();

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
