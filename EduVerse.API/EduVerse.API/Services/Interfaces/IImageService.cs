namespace EduVerse.API.Services.Interfaces
{
    public interface IImageService
    {
        Task UploadPhotoAsync(IFormFile img, string fileFolder, string fileName);
        Task DeletePhotoAsync(string fileFolder, string fileName);
    }
}
