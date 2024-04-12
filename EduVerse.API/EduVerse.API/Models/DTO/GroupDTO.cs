namespace EduVerse.API.Models.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public int CuratorId { get; set; }
        public IList<int> StudentIds { get; set; } = new List<int>();
        public IList<int> LessonIds { get; set; } = new List<int>();
        public IList<int> GroupScheduleIds { get; set; } = new List<int>();
    }
}
