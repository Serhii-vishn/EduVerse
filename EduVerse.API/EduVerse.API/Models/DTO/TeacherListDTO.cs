namespace EduVerse.API.Models.DTO
{
    public class TeacherListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;
    }
}
