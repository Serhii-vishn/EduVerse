namespace EduVerse.API.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<TeacherEntity?> GetAsync(int id);
        Task<TeacherEntity?> GetAsync(string phoneNumber);
        Task<TeacherEntity?> GetAsync(string lastName, string firstName, DateOnly dateOfBirth);
        Task<TeacherEntity?> GetAllAsync(int id);
        Task<IList<TeacherEntity>> ListAsync();
        Task<IList<TeacherEntity>> ListFilteredAsync(string filterOn, string filterQuery);
        Task<int> AddAsync(TeacherEntity teacher);
        Task<int> UpdateAsync(TeacherEntity teacher);
        Task<int> DeleteAsync(int id);
    }
}
