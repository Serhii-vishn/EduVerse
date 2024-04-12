namespace EduVerse.API.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<AttendanceEntity?> GetAsync(int id);
        Task<IList<AttendanceEntity>> ListAsync();
        Task<int> AddAsync(AttendanceEntity attendance);
        Task<int> UpdateAsync(AttendanceEntity attendance);
        Task<int> DeleteAsync(int id);
    }
}
