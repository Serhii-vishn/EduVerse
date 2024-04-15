namespace EduVerse.API.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> GetAsync(int id);
        Task<IList<ScheduleListDTO>> ListAsync();
        Task<int> UpdateAsync(ScheduleDTO schedule);
    }
}
