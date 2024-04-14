namespace EduVerse.API.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<TeacherEntity?> GetAsync(int id);
        Task<IList<TeacherEntity>> ListAsync();
        Task<int> AddAsync(TeacherEntity teacher);
        Task<int> UpdateAsync(TeacherEntity teacher);
        Task<int> DeleteAsync(int id);
    }
}
