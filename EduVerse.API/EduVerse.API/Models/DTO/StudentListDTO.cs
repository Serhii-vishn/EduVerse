namespace EduVerse.API.Models.DTO
{
    public class StudentListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;
    }
}
