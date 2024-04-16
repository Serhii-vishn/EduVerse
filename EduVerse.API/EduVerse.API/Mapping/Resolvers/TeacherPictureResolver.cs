namespace EduVerse.API.Mapping.Resolvers
{
    public class TeacherPictureResolver : IValueResolver<TeacherEntity, TeacherDTO, string>
    {
        private readonly AppConfig _config;

        public TeacherPictureResolver(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Resolve(TeacherEntity source, TeacherDTO destination, string destMember, ResolutionContext context)
        {
            if (source.PictureFileName is null)
            {
                return $"{_config.ApiHost}/{_config.ImgUrl}/no-image.jpg";
            }

            return $"{_config.ApiHost}/{_config.ImgUrl}/coaches/{source.PictureFileName}";
        }
    }
}
