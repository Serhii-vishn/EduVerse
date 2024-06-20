namespace EduVerse.API.Data.Entities
{
    public class ParentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string ParentalStatus { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Work { get; set; }
        public string? PictureFileName { get; set; }

        public IList<StudentEntity> Childrens { get; set; } = new List<StudentEntity>();

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
