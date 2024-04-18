namespace EduVerse.API.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> GetAsync(int id);
        Task<ScheduleLessonDTO> GetByLessonIdAsync(int scheduledLessonId);
        Task<IList<ScheduleListDTO>> ListAsync();
        Task<int> UpdateAsync(ScheduleDTO schedule);
    }
}
