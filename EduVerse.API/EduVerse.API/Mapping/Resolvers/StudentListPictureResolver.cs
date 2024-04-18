namespace EduVerse.API.Mapping.Resolvers
{
    public class StudentListPictureResolver : IValueResolver<StudentEntity, StudentListDTO, string>
    {
        private readonly AppConfig _config;

        public StudentListPictureResolver(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Resolve(StudentEntity source, StudentListDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureFileName))
            {
                return $"{_config.ApiHost}/{_config.ImgUrl}/no-image.jpg";
            }

            return $"{_config.ApiHost}/{_config.ImgUrl}/Students/{source.PictureFileName}";
        }
    }
}
