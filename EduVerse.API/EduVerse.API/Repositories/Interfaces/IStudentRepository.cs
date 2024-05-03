namespace EduVerse.API.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentEntity?> GetAsync(int id);
        Task<StudentEntity?> GetAsync(string lastName, string firstName, DateOnly dateOfBirth);
        Task<StudentEntity?> GetAllAsync(int id);
        Task<IList<StudentEntity>> ListAsync();
        Task<int> AddAsync(StudentEntity student);
        Task<int> UpdateAsync(StudentEntity student);
        Task<int> DeleteAsync(int id);
    }
}
