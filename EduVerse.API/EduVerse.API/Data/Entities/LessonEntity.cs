namespace EduVerse.API.Data.Entities
{
    public class LessonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public IList<TeacherEntity> Teachers { get; set; } = new List<TeacherEntity>();

        public IList<GroupEntity> Groups { get; set; } = new List<GroupEntity>();

        public IList<ScheduleEntity> ScheduleLessons { get; set; } = new List<ScheduleEntity>();
    }
}
