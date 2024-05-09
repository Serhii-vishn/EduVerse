namespace EduVerse.API.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetAsync(int id);
        Task<TeacherDTO> GetAsync(string email);
        Task<IList<TeacherListDTO>> ListAsync(string? filterOn = null, string? filterQuery = null);
        Task<int> AddAsync(AddTeacherRequest teacher);
        Task AddPhotoAsync(string email, IFormFile image);
        Task<int> UpdateAsync(UpdateTeacherRequest teacher);
        Task<int> DeleteAsync(int id);
    }
}
