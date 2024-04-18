namespace EduVerse.API.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<ScheduleEntity?> GetAsync(int id);
        Task<ScheduleEntity?> GetAllAsync(int id);
        Task<IList<ScheduleEntity>> ListAllAsync();
        Task<int> AddAsync(ScheduleEntity schedule);
        Task<int> UpdateAsync(ScheduleEntity schedule);
        Task<int> DeleteAsync(int id);
    }
}
