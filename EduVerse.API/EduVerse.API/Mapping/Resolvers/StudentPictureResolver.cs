namespace EduVerse.API.Mapping.Resolvers
{
    public class StudentPictureResolver : IValueResolver<StudentEntity, StudentDTO, string>
    {
        private readonly AppConfig _config;

        public StudentPictureResolver(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Resolve(StudentEntity source, StudentDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureFileName))
            {
                return $"{_config.ApiHost}/{_config.ImgUrl}/no-image.jpg";
            }

            return $"{_config.ApiHost}/{_config.ImgUrl}/Students/{source.PictureFileName}";
        }
    }
}
