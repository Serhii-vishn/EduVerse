namespace EduVerse.API.Data.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IList<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
