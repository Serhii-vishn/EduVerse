namespace EduVerse.API.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        Task<GradeEntity?> GetAsync(int id);
        Task<IList<GradeEntity>> ListAsync();
        Task<int> AddAsync(GradeEntity grade);
        Task<int> UpdateAsync(GradeEntity grade);
        Task<int> DeleteAsync(int id);
    }
}
