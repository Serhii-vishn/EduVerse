﻿namespace EduVerse.API.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetAsync(int id);
        Task<IList<TeacherListDTO>> ListAsync();
        Task<int> AddAsync(TeacherDTO teacher);
        Task<int> UpdateAsync(TeacherDTO teacher);
        Task<int> DeleteAsync(int id);
    }
}
