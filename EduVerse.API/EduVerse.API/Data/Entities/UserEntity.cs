namespace EduVerse.API.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public IList<RoleEntity> Roles { get; set; } = new List<RoleEntity>();

        public int? TeacherId { get; set; }
        public TeacherEntity? Teacher { get; set; }

        public int? StudentId { get; set; }
        public StudentEntity? Student { get; set; }

        public int? ParentId { get; set; }
        public ParentEntity? Parent { get; set; }
    }
}
