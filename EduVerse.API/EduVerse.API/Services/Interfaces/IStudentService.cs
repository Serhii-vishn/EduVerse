namespace EduVerse.API.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetAsync(int id);
        Task<IList<StudentListDTO>> ListAsync();
        Task<int> AddAsync(StudentDTO student);
        Task<int> UpdateAsync(StudentDTO student);
        Task<int> DeleteAsync(int id);
    }
}
