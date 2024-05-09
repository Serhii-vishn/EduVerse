namespace EduVerse.API.Services
{
    public class ImageService : IImageService
    {
        private readonly AppConfig _config;

        public ImageService(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task UploadPhotoAsync(IFormFile img, string fileFolder, string fileName)
        {
            if (img is null || img.Length <= 0)
            {
                throw new ArgumentException("File is empty");
            }

            var filePath = Path.Combine($"wwwroot/{_config.ImgUrl}/{fileFolder}/{fileName}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }
        }

        public async Task DeletePhotoAsync(string fileFolder, string fileName)
        {
            var filePath = Path.Combine($"wwwroot/{_config.ImgUrl}/{fileFolder}/{fileName}");

            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
