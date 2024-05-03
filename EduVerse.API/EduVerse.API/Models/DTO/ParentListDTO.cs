namespace EduVerse.API.Models.DTO
{
    public class ParentListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;
    }
}
