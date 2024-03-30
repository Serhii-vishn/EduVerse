namespace EduVerse.API.Data.Entities
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = null!;

        public int CuratorId { get; set; }
        public TeacherEntity Curator { get; set; } = null!;

        public IList<StudentEntity> Students { get; set; } = new List<StudentEntity>();

        public IList<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();
    }
}
