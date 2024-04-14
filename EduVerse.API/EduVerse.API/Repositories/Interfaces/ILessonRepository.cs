namespace EduVerse.API.Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task<LessonEntity?> GetAsync(int id);
        Task<IList<LessonEntity>> ListAsync();
        Task<int> AddAsync(LessonEntity lesson);
        Task<int> UpdateAsync(LessonEntity lesson);
        Task<int> DeleteAsync(int id);
    }
}
