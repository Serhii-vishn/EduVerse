namespace EduVerse.API.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<GroupEntity?> GetAsync(int id);
        Task<IList<GroupEntity>> ListAsync();
        Task<int> AddAsync(GroupEntity group);
        Task<int> UpdateAsync(GroupEntity group);
        Task<int> DeleteAsync(int id);
    }
}
