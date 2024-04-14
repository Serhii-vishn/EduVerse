namespace EduVerse.API.Repositories.Interfaces
{
    public interface IParentRepository
    {
        Task<ParentEntity?> GetAsync(int id);
        Task<IList<ParentEntity>> ListAsync();
        Task<int> AddAsync(ParentEntity parent);
        Task<int> UpdateAsync(ParentEntity parent);
        Task<int> DeleteAsync(int id);
    }
}
