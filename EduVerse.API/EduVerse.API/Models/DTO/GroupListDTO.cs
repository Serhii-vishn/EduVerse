namespace EduVerse.API.Models.DTO
{
    public class GroupListDTO
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public string CuratorFullName { get; set; } = null!;
    }
}
