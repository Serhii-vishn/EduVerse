namespace EduVerse.API.Models.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;
        public int GroupId { get; set; }
        public GroupDTO Group { get; set; } = null!;
    }
}
