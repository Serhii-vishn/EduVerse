namespace EduVerse.API.Data.Entities
{
    public class ParentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBith { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Work { get; set; }
        public string? PictureFileName { get; set; }

        public IList<StudentEntity> Childrens { get; set; } = new List<StudentEntity>();
    }
}
